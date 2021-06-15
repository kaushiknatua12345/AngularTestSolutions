import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { FormsModule } from '@angular/forms';
import { By } from '@angular/platform-browser';

import { TraineeComponent } from './trainee.component';

describe('TraineeComponent', () => {
  let component: TraineeComponent;
  let fixture: ComponentFixture<TraineeComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TraineeComponent ],
      imports:[FormsModule]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TraineeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create TraineeComponent', () => {
    expect(component).toBeTruthy();
  });

  it('Trainee Name - Check | No Data Supplied But Input Field is Touched',async()=>
  {
    fixture.whenStable().then(()=>{
    let traineename=component.registerForm.form.controls['traineename'];    
    traineename.setValue('');
    expect(traineename.touched).toBeFalsy();
    expect(traineename.valid).toBeFalsy();
    expect(component.registerForm.valid).toBeFalsy();
    });
  
  });

  it('Enmail Id - Check | No Data Supplied But Input Field is Touched',async()=>
  {
    fixture.whenStable().then(()=>{
      let emailid=component.registerForm.form.controls['emailid'];      
      emailid.setValue('');
      expect(emailid.touched).toBeFalsy();
      expect(emailid.valid).toBeFalsy();
      expect(component.registerForm.valid).toBeFalsy();
    });
    
  });

  it('Email Id - Check | Invalid Email Id Supplied',async()=>
  {
    fixture.whenStable().then(()=>{
    let emailid=component.registerForm.form.controls['emailid'];    
    emailid.setValue('abc');
    expect(emailid.errors['email']).toBeTruthy();
    expect(emailid.valid).toBeFalsy();
    expect(component.registerForm.valid).toBeFalsy();
    });
  });

    it('When Both Trainee Name and Email Is Valid, Form Should be submitted Successfully',async()=>{
      fixture.whenStable().then(()=>{
        let traineename=component.registerForm.form.controls['traineename'];
        let emailid=component.registerForm.form.controls['emailid'];
        traineename.setValue('Sam');
        emailid.setValue('sam@gmail.com');
        component.submitForm();
        fixture.detectChanges();
        let successMsg=fixture.debugElement.query(By.css('#success-msg'));
        expect(successMsg.nativeElement.innerText).toBe(component.message);
      });
    });
    
 
});
