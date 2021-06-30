import { TestBed, async } from '@angular/core/testing';
import { AppComponent } from './app.component';
import { MessageComponent } from './../app/message/message.component';

describe('AppComponent', () => {
  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [
        AppComponent,
        MessageComponent
      ],
    }).compileComponents();
  }));

  it('should create the AppComponent', () => {
    const fixture = TestBed.createComponent(AppComponent);
    const app = fixture.debugElement.componentInstance;
    expect(app).toBeTruthy();
  });

  it(`should have a parent own message 'This is a message from parent component'`, () => {
    const fixture = TestBed.createComponent(AppComponent);
    const app = fixture.debugElement.componentInstance;
    expect(app.message).toEqual('This is a message from parent component');
  });

  it('should render parent own message in a h1 tag', () => {
    const fixture = TestBed.createComponent(AppComponent);
    fixture.detectChanges();
    const compiled = fixture.debugElement.nativeElement;
    expect(compiled.querySelector('h1').textContent).toContain('Parent Compoent Message: This is a message from parent component');
  });
  
});
