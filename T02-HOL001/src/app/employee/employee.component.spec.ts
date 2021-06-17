import { DebugElement } from '@angular/core';
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';

import { EmployeeComponent } from './employee.component';

describe('EmployeeComponent', () => {
  let component: EmployeeComponent;
  let fixture: ComponentFixture<EmployeeComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ EmployeeComponent ]
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

  it(`should have a title 'employee information'`, () => {
    const fixture = TestBed.createComponent(EmployeeComponent);
    const app = fixture.debugElement.componentInstance;
    expect(app.title).toEqual('employee information');
  });

  it(`should have an employee name 'sam'`, () => {
    const fixture = TestBed.createComponent(EmployeeComponent);
    const app = fixture.debugElement.componentInstance;
    expect(app.name).toEqual('sam');
  });

  it(`should have an employee salary '90000'`, () => {
    const fixture = TestBed.createComponent(EmployeeComponent);
    const app = fixture.debugElement.componentInstance;
    expect(app.salary).toEqual(90000);
  });

  it(`should have an employee joining date '2015/05/20'`, () => {
    const fixture = TestBed.createComponent(EmployeeComponent);
    const app = fixture.debugElement.componentInstance;
    expect(app.joiningDate).toEqual(new Date("2021/05/20"));
  });

  it('should render title in a h1 tag', () => {
    const fixture = TestBed.createComponent(EmployeeComponent);
    fixture.detectChanges();
    const compiled = fixture.debugElement.nativeElement;
    expect(compiled.querySelector('h1').textContent).toContain('Employee Information');
  });

  it('should render employee name in a h2 tag', () => {
    const fixture = TestBed.createComponent(EmployeeComponent);
    const bannerDe:DebugElement=fixture.debugElement;
    const nameDisplay=bannerDe.query(By.css('#name'));
    const nameDisplayEle:HTMLElement=nameDisplay.nativeElement;
    fixture.detectChanges();
    expect(nameDisplayEle.textContent).toContain('Name: SAM');
  });

  it('should render employee salary in a h2 tag', () => {
    const fixture = TestBed.createComponent(EmployeeComponent);
    const bannerDe:DebugElement=fixture.debugElement;
    const salaryDisplay=bannerDe.query(By.css('#salary'));
    const slaryDisplayEle:HTMLElement=salaryDisplay.nativeElement;
    fixture.detectChanges();
    expect(slaryDisplayEle.textContent).toContain('Salary: ₹90,000.00');
  });

  it('should render employee joining date in a h2 tag', () => {
    const fixture = TestBed.createComponent(EmployeeComponent);
    const bannerDe:DebugElement=fixture.debugElement;
    const joiningDateDisplay=bannerDe.query(By.css('#joiningDate'));
    const joiningDateDisplayEle:HTMLElement=joiningDateDisplay.nativeElement;
    fixture.detectChanges();
    expect(joiningDateDisplayEle.textContent).toContain('Date Of Joining: Thursday, May 20, 2021');
  });
});
