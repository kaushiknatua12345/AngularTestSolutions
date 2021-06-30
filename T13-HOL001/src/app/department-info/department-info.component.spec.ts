import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { ActivatedRoute } from '@angular/router';
import { of } from 'rxjs';
import {RouterTestingModule} from '@angular/router/testing';
import { HttpClientTestingModule, HttpTestingController } from '@angular/common/http/testing';
import { DepartmentInfoComponent } from './department-info.component';

describe('DepartmentInfoComponent', () => {
  let component: DepartmentInfoComponent;
  let fixture: ComponentFixture<DepartmentInfoComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ DepartmentInfoComponent ],
      imports: [
        RouterTestingModule,
        HttpClientTestingModule       
      ],
      providers:
      [
        {
          provide: ActivatedRoute,
          useValue: {
            snapshot: {params: {DepaertmentName: 'HR'}}
          }
        }
      ]
    })
    .compileComponents();
}));

  beforeEach(() => {
    fixture = TestBed.createComponent(DepartmentInfoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });  

  it('should create DepartmentInfoComponent', () => {
    expect(component).toBeTruthy();
  });

  it(`should have as department name 'HR'`,  async() => {    
    const fixture = TestBed.createComponent(DepartmentInfoComponent);
    let activeRoute=new ActivatedRoute();
    const app = fixture.debugElement.componentInstance;
    fixture.whenStable().then(() => {
    expect(activeRoute.snapshot.params.DepartmentName).toEqual('HR');
    });
  });

  it('should render department name in a h2 tag', async() => {
    const fixture = TestBed.createComponent(DepartmentInfoComponent);   
    fixture.detectChanges();
    const compiled = fixture.debugElement.nativeElement;
    let activeRoute=new ActivatedRoute();
    
    fixture.whenStable().then(() => {
    expect(compiled.querySelector('h2').textContent).toContain('Department Name Called Under DepartmentInfo Component: '+activeRoute.snapshot.params.DepartmentName);
    });
  });
});
