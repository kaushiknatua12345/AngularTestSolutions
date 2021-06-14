import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { PhonenumberPipe } from '../phonenumber.pipe';
import { DebugElement } from '@angular/core';
import { By } from '@angular/platform-browser';

import { EmployeeComponent } from './employee.component';

describe('EmployeeComponent', () => {
  let component: EmployeeComponent;
  let fixture: ComponentFixture<EmployeeComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ EmployeeComponent,PhonenumberPipe ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(EmployeeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create EmployeeComponent', () => {
    expect(component).toBeTruthy();
  });

  it(`should have a title 'employee details'`, () => {
    const fixture = TestBed.createComponent(EmployeeComponent);
    const app = fixture.debugElement.componentInstance;
    expect(app.title).toEqual('employee details');
  });

  it(`should have a name 'sam'`, () => {
    const fixture = TestBed.createComponent(EmployeeComponent);
    const app = fixture.debugElement.componentInstance;
    expect(app.name).toEqual('sam');
  });

  it(`should have an landline number '0442567100'`, () => {
    const fixture = TestBed.createComponent(EmployeeComponent);
    const app = fixture.debugElement.componentInstance;
    expect(app.landlineNumber).toEqual('0442567100');
  });

  it('should render title in a h1 tag', () => {
    const fixture = TestBed.createComponent(EmployeeComponent);
    fixture.detectChanges();
    const compiled = fixture.debugElement.nativeElement;
    expect(compiled.querySelector('h1').textContent).toContain('Employee Details');
  });

  it('should render employee name in a h2 tag', () => {
    const fixture = TestBed.createComponent(EmployeeComponent);
    const bannerDe:DebugElement=fixture.debugElement;
    const nameDisplay=bannerDe.query(By.css('#name'));
    const nameDisplayEle:HTMLElement=nameDisplay.nativeElement;
    fixture.detectChanges();
    expect(nameDisplayEle.textContent).toContain('Name : SAM');
  });

  it('should render landline number in a h2 tag', () => {
    const fixture = TestBed.createComponent(EmployeeComponent);
    const bannerDe:DebugElement=fixture.debugElement;
    const landlineDisplay=bannerDe.query(By.css('#phoneNumber'));
    const landlineDisplayEle:HTMLElement=landlineDisplay.nativeElement;
    fixture.detectChanges();
    expect(landlineDisplayEle.textContent).toContain('Landline Number : (044) 256 7100');
  });

});


