import { Output } from '@angular/core';
import { ViewChild } from '@angular/core';
import { ElementRef } from '@angular/core';
import { EventEmitter } from '@angular/core';
import { Input } from '@angular/core';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-message',
  templateUrl: './message.component.html',
  styleUrls: ['./message.component.css']
})
export class MessageComponent {
  @Input() message: string;    
  @Output() messageEmitter=new EventEmitter<string>(); 
  handleButtonClick(newMessage:string) {
    if(newMessage) {
      this.messageEmitter.emit(newMessage);      
    } 
  }
}
