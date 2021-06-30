import { TestBed, async, inject } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { RouterTestingModule } from '@angular/router/testing';
import { AboutusComponent } from './aboutus/aboutus.component';
import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component';

describe('AppComponent', () => {
  beforeEach(async(() => {
    TestBed.configureTestingModule({
      imports: [
        RouterTestingModule.withRoutes([
          { path: 'Home', component: HomeComponent },
          {path:'AboutUs',component:AboutusComponent}
         ])
      ],
      declarations: [
        AppComponent,HomeComponent,AboutusComponent
      ],
    }).compileComponents();
  }));

  it('should create the app', () => {
    const fixture = TestBed.createComponent(AppComponent);
    const app = fixture.debugElement.componentInstance;
    expect(app).toBeTruthy();
  });
  
  it('Should Route To Home Component',
  async() => {
  let fixture = TestBed.createComponent(AppComponent);
  fixture.detectChanges();
  let href=fixture.debugElement.query(By.css('a')).nativeElement
  .getAttribute('href');
  fixture.whenStable().then(() => {
    expect(href).toEqual('/Home');    
    console.log('after expect');
  });
  });

  it('Should Route To About Us Component',
  async() => {
  let fixture = TestBed.createComponent(AppComponent);
  fixture.detectChanges();
  let href=fixture.debugElement.query(By.css('#link2')).nativeElement
  .getAttribute('href');
  fixture.whenStable().then(() => {
    expect(href).toEqual('/AboutUs');    
    console.log('after expect');
  });
  });
 
});
