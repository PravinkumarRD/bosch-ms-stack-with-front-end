import { Component, OnInit, OnDestroy } from '@angular/core';
import { CommonModule } from "@angular/common";
import { Subscription } from "rxjs";

import { Event } from "../../models/event"; import { EventDetailsComponent } from '../event-details/event-details.component';

import { DateGlobalizationPipe } from '../../../shared/pipes/date-globalization.pipe';

import { EventsService } from '../../services/events.service';
import { RouterLink } from '@angular/router';
;

@Component({
  selector: 'bosch-events-list',
  standalone: true,
  imports: [CommonModule,  DateGlobalizationPipe,RouterLink],
  templateUrl: './events-list.component.html',
  styleUrl: './events-list.component.css',
  providers: [EventsService]
})
export class EventsListComponent implements OnInit, OnDestroy {
  constructor(private _eventsService: EventsService) {

  }
  private _eventsServiceSubscription: Subscription;
  title: string = "Welcome To Bosch Events List!";
  subTitle: string = "Published by Bosch Hr Team! India!";
  events: Event[];
  // selectedEvent: Event;
  //selectedEventId:number;
  ngOnInit(): void {
    this._eventsServiceSubscription = this._eventsService.getAllEvents().subscribe({
      next: data => this.events = data,
      error: err => console.log(err)
    });
  }

  // onEventSelection(eventId: number): void {
  //   this.selectedEventId = eventId;
  // }
  ngOnDestroy(): void {
    if(this._eventsServiceSubscription) this._eventsServiceSubscription.unsubscribe();
  }
}
