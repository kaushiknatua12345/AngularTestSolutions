import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import { HoverFocusDirective } from './hover-focus.directive';
import { TestHoverFocusComponent } from './test-hover-focus/test-hover-focus.component';
import { ABCDirective } from './abc.directive';

@NgModule({
  declarations: [
    AppComponent,
    HoverFocusDirective,
    TestHoverFocusComponent,
    ABCDirective
  ],
  imports: [
    BrowserModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
