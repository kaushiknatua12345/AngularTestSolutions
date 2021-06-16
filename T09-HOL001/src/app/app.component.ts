import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  message = 'This is a message from parent component';
  childMNessage:string; 
  childMessage(newmessage:string) {
    this.childMNessage = newmessage;
  } 
}
