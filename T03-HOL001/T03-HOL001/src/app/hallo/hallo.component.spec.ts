import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { HalloComponent } from './hallo.component';
import { CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';

describe('HalloComponent', () => {
  let component: HalloComponent;
  let fixture: ComponentFixture<HalloComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ HalloComponent ],
      schemas: [CUSTOM_ELEMENTS_SCHEMA]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(HalloComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create HalloComponent', () => {
    const fixture = TestBed.createComponent(HalloComponent);
    const app = fixture.debugElement.componentInstance;
    expect(app).toBeTruthy();
  });

  it('Check whether the addition of 10 and 20 gives expected result 30',()=>{
    const fixture = TestBed.createComponent(HalloComponent);
    const app = fixture.debugElement.componentInstance;
    expect(app.Addition(10,20)).toEqual(30);
  });
  it('should render addition result in a h2 tag', () => {
    const fixture = TestBed.createComponent(HalloComponent);
    fixture.detectChanges();
    const compiled = fixture.debugElement.nativeElement;
    expect(compiled.querySelector('h2').textContent).toContain('Addition of 10 + 20 = 30');
  });
});
