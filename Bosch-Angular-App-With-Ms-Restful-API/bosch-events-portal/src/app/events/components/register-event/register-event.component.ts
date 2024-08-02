import { Component } from '@angular/core';
import { ReactiveFormsModule } from '@angular/forms';

import { NewEvent } from "../../models/new-event";

@Component({
  selector: 'bosch-register-event',
  standalone: true,
  imports: [ReactiveFormsModule],
  templateUrl: './register-event.component.html',
  styleUrl: './register-event.component.css'
})
export class RegisterEventComponent {
  title: string = "Register Upcoming Event Of Bosch! India!";
  newEvent: NewEvent = new NewEvent();
  onEventSubmit():void{
    console.log(this.newEvent.registrationForm.value)
  }
}
