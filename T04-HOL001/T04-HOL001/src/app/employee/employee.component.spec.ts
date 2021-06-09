import { async, ComponentFixture, TestBed } from '@angular/core/testing';

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

  it('should create Employee Conmponent', () => {
    expect(component).toBeTruthy();
  });

  it(`should have as title 'Employee Information'`, () => {
    const fixture = TestBed.createComponent(EmployeeComponent);
    const app = fixture.debugElement.componentInstance;
    expect(app.title).toEqual('Employee Information');
  });

  it('should render title in a h1 tag', () => {
    const fixture = TestBed.createComponent(EmployeeComponent);
    fixture.detectChanges();
    const compiled = fixture.debugElement.nativeElement;
    expect(compiled.querySelector('h1').textContent).toContain('Employee Information');
  });

  it('DisplayId method should be defined', () => {
    expect(component.DisplayId()).toBeDefined("Method DisplayId() should be defined");
  });

  it('DisplayName method should be defined', () => {
    expect(component.DisplayName()).toBeDefined("Method DisplayName() should be defined");
  });

  it('DisplaySalary method should be defined', () => {
    expect(component.DisplaySalary()).toBeDefined("Method DisplaySalary() should be defined");
  });

  it('DisplayPermanentOrNot method should be defined', () => {
    expect(component.DisplayPermanentOrNot()).toBeDefined("Method DisplayPermanentOrNot() should be defined");
  });
  

  it('DisplayId method should return a 4 digit id >=1000', () => {
    expect(component.DisplayId()).toBeGreaterThanOrEqual(1000);
  });

  it('DisplayName method should not return blank', () => {
    expect(component.DisplayName()).not.toEqual("");
  });

  it('DisplaySalary method should be defined', () => {
    expect(component.DisplaySalary()).toBeGreaterThanOrEqual(3000);
  });
  

  it('should render id in a h2 tag', () => {
    const fixture = TestBed.createComponent(EmployeeComponent);
    const app = fixture.debugElement.componentInstance;
    fixture.detectChanges();
    const compiled = fixture.debugElement.nativeElement;
    expect(compiled.querySelector('h2').textContent).toContain('Id: '+app.DisplayId());    
  });

  it('should render name in a h2 tag', () => {
    const fixture1 = TestBed.createComponent(EmployeeComponent);
    const app1 = fixture1.debugElement.componentInstance;
    fixture1.detectChanges();
    const compiled1 = fixture1.debugElement.nativeElement;
    expect(compiled1.querySelector('h2').textContent).toContain('Name: '+app1.DisplayName());
  });

  it('should render salary in a h2 tag', () => {
    const fixture = TestBed.createComponent(EmployeeComponent);
    const app = fixture.debugElement.componentInstance;
    fixture.detectChanges();
    const compiled = fixture.debugElement.nativeElement;
    expect(compiled.querySelector('h2').textContent).toContain('Salary: '+app.DisplaySalary());
  });

  it('should render permanent or not in a h2 tag', () => {
    const fixture = TestBed.createComponent(EmployeeComponent);
    const app = fixture.debugElement.componentInstance;
    fixture.detectChanges();
    const compiled = fixture.debugElement.nativeElement;
    expect(compiled.querySelector('h2').textContent).toContain('Permanent: '+app.DisplayPermanentOrNot());
  });

  
});
