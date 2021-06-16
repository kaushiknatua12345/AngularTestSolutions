import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { By } from '@angular/platform-browser';

import { TraineeComponent } from './trainee.component';

describe('TraineeComponent', () => {
  let component: TraineeComponent;
  let fixture: ComponentFixture<TraineeComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TraineeComponent ],
      imports:[FormsModule,ReactiveFormsModule]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TraineeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create Trainee Component', () => {
    expect(component).toBeTruthy();
  });

  it(`should have as title 'Trainee Registration Form'`, () => {
    const fixture = TestBed.createComponent(TraineeComponent);
    const app = fixture.debugElement.componentInstance;
    expect(app.title).toEqual('Trainee Registration Form');
  });

  it('should render title in a h1 tag', () => {
    const fixture = TestBed.createComponent(TraineeComponent);
    fixture.detectChanges();
    const compiled = fixture.debugElement.nativeElement;
    expect(compiled.querySelector('h1').textContent).toContain('Trainee Registration Form');
  });

  it('Trainee Name - Check | No Data Supplied But Input Field is Touched',()=>
  {   
    let studentname=component.studentForm.controls['studentName'];    
    studentname.setValue('');
    expect(studentname.touched).toBeFalsy();
    expect(studentname.valid).toBeFalsy();
    expect(studentname.errors['required']).toBeTruthy();
    expect(component.studentForm.valid).toBeFalsy(); 
  });

  it('Email Id - Check | No Data Supplied But Input Field is Touched',()=>
  {   
    let emailid=component.studentForm.controls['emailid'];    
    emailid.setValue('');
    expect(emailid.touched).toBeFalsy();
    expect(emailid.valid).toBeFalsy();
    expect(emailid.errors['required']).toBeTruthy();
    expect(component.studentForm.valid).toBeFalsy(); 
  });

  it('Email Id - Check | Invalid Email Id Supplied',()=>
  {   
    let emailid=component.studentForm.controls['emailid'];     
    emailid.setValue('abc');
    expect(emailid.errors['email']).toBeTruthy();
    expect(emailid.valid).toBeFalsy();
    expect(component.studentForm.valid).toBeFalsy();    
  });

  it('When Both Trainee Name and Email Is Valid, Form Should be submitted Successfully',()=>{   
      let studentname=component.studentForm.controls['studentName'];  
      let emailid=component.studentForm.controls['emailid']; 
      studentname.setValue('Sam');
      emailid.setValue('sam@gmail.com');
      component.SubmitForm();
      fixture.detectChanges();
      let successMsg=fixture.debugElement.query(By.css('#success-msg'));
      expect(successMsg.nativeElement.innerText).toBe(component.message);
    });

});
