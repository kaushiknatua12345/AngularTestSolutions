import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { MessageComponent } from './message.component';

describe('MessageComponent', () => {
  let component: MessageComponent;
  let fixture: ComponentFixture<MessageComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ MessageComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(MessageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create MessageComponent', () => {
    expect(component).toBeTruthy();
  });  

  it('should correctly render the passed @Input value', () => {
    component.message = 'Calling Parent Message in Child Message Component'; 
    fixture.detectChanges(); 
    const compiled = fixture.debugElement.nativeElement; 
    expect(compiled.querySelector('h2').textContent).toBe('Parent Component Message Call: Calling Parent Message in Child Message Component'); 
  });

  it('should correctly @Output value of text input in Message Component', () => {
    spyOn(component.messageEmitter, 'emit'); 
    const button = fixture.nativeElement.querySelector('button');
    fixture.nativeElement.querySelector('input').value = 'Welcome User'; 
    const inputText = fixture.nativeElement.querySelector('input').value;    
    button.click(); 
    fixture.detectChanges();   
    expect(component.messageEmitter.emit).toHaveBeenCalledWith(inputText); 
  });
});
