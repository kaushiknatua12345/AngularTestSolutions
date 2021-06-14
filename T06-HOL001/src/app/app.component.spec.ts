import { TestBed, async } from '@angular/core/testing';
import { FormsModule } from '@angular/forms';
import { AppComponent } from './app.component';
import { DebugElement } from '@angular/core';
import { By } from '@angular/platform-browser';



describe('AppComponent', () => {
  beforeEach(async(() => {
    TestBed.configureTestingModule({
      imports:[FormsModule],
      declarations: [
        AppComponent
      ],
    }).compileComponents();
  }));

  it('should create the app', () => {
    const fixture = TestBed.createComponent(AppComponent);
    const app = fixture.debugElement.componentInstance;
    expect(app).toBeTruthy();
  });

  it(`should have as title 'Calculator Application'`, () => {
    const fixture = TestBed.createComponent(AppComponent);
    const app = fixture.debugElement.componentInstance;
    expect(app.title).toEqual('Calculator Application');
  });

  it('should render title in a h1 tag', () => {
    const fixture = TestBed.createComponent(AppComponent);
    fixture.detectChanges();
    const compiled = fixture.debugElement.nativeElement;
    expect(compiled.querySelector('h1').textContent).toContain('Calculator Application');
  });
  

  it(`when numbers are greater than 0 and Addition button is clicked it should give addition result`, () => {
    const fixture = TestBed.createComponent(AppComponent);
    const app = fixture.debugElement.componentInstance;
    app.num1=10;
    app.num2=20;   
    fixture.detectChanges();   
    expect(app.Addition(app.num1,app.num2)).toEqual('The Addition Result is: 30'); 
  });

  it(`when numbers are less than or equal to zero and Addition button is clicked it should give invalid message`, () => {
    const fixture = TestBed.createComponent(AppComponent);
    const app = fixture.debugElement.componentInstance;
    app.num1=10;
    app.num2=0;   
    fixture.detectChanges();   
    expect(app.Addition(app.num1,app.num2)).toEqual('Invalid Input'); 
  });

  it(`when numbers are greater than 0 and Substraction button is clicked it should give substraction result in h2 tag`, () => {
    const fixture = TestBed.createComponent(AppComponent);
    const app = fixture.debugElement.componentInstance;  
    fixture.detectChanges()
    app.num1=25;
    app.num2=20;
    expect(app.Substraction(app.num1,app.num2)).toEqual('The Substraction Result is: 5');
    });

    it(`when numbers are less than or equal to zero and substraction button is clicked it should give invalid message`, () => {
      const fixture = TestBed.createComponent(AppComponent);
      const app = fixture.debugElement.componentInstance;
      app.num1=10;
      app.num2=0;   
      fixture.detectChanges();   
      expect(app.Substraction(app.num1,app.num2)).toEqual('Invalid Input'); 
    });

  it(`when numbers are greater than 0 and Multiplication button is clicked it should give multiplication result`, () => {
    const fixture = TestBed.createComponent(AppComponent);
    const app = fixture.debugElement.componentInstance;
    fixture.detectChanges()
    app.num1=10;
    app.num2=2;      
    expect(app.Multiplication(app.num1,app.num2)).toEqual('The Multiplication Result is: 20');
  });

  it(`when numbers are less than or equal to zero and multiplication button is clicked it should give invalid message`, () => {
    const fixture = TestBed.createComponent(AppComponent);
    const app = fixture.debugElement.componentInstance;
    app.num1=10;
    app.num2=0;   
    fixture.detectChanges();   
    expect(app.Multiplication(app.num1,app.num2)).toEqual('Invalid Input'); 
  });


    it(`when numbers are greater than 0 and Division button is clicked it should give vivision result`, () => {
      const fixture = TestBed.createComponent(AppComponent);
      const app = fixture.debugElement.componentInstance;
      fixture.detectChanges()
      app.num1=7;
      app.num2=2;
      expect(app.Division(app.num1,app.num2)).toEqual('The Division Result is: 3.5');      
  });

  it(`when numbers are less than or equal to zero and division button is clicked it should give invalid message`, () => {
    const fixture = TestBed.createComponent(AppComponent);
    const app = fixture.debugElement.componentInstance;
    app.num1=0;
    app.num2=20;   
    fixture.detectChanges();   
    expect(app.Division(app.num1,app.num2)).toEqual('Invalid Input'); 
  });

  it('should render result in a h2 tag with valid input', () => {
    const fixture = TestBed.createComponent(AppComponent);
    const app = fixture.debugElement.componentInstance;
    fixture.detectChanges();
    const compiled = fixture.debugElement.nativeElement;
    app.num1=10;
    app.num2=20;   
    app.check=true;
    app.output=app.Addition(app.num1,app.num2);
    expect(compiled.querySelector('h2').textContent).withContext(app.output);
  });

  it('should render invalid message in a h2 tag with invalid input', () => {
    const fixture = TestBed.createComponent(AppComponent);
    const app = fixture.debugElement.componentInstance;
    fixture.detectChanges();
    const compiled = fixture.debugElement.nativeElement;
    app.num1=0;
    app.num2=20;   
    app.check=false;
    app.output=app.Addition(app.num1,app.num2);
    expect(compiled.querySelector('h2').textContent).withContext(app.output);
  });
});
