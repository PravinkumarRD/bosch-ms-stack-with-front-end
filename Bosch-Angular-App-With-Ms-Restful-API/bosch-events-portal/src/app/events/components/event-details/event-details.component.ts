// import { Component, Input, OnChanges, OnDestroy, SimpleChanges } from '@angular/core';
import { Component, OnInit, OnDestroy } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Subscription } from "rxjs";

import { Event } from "../../models/event";

import { EventsService } from '../../services/events.service';
import { ActivatedRoute } from '@angular/router';


@Component({
  selector: 'bosch-event-details',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './event-details.component.html',
  styleUrl: './event-details.component.css',
  providers: [EventsService]
})
export class EventDetailsComponent implements OnInit, OnDestroy {
  constructor(private _activatedRoute: ActivatedRoute, private _eventsService: EventsService) {

  }
  private _eventsServiceSubscription: Subscription;
  title: string = "Details Of - ";
  // @Input() eventId: number;
  event: Event;
  // ngOnChanges(changes: SimpleChanges): void {
  ngOnInit(): void {
    let eventId = Number.parseInt(this._activatedRoute.snapshot.params['id']);
    console.log(eventId)
    this._eventsServiceSubscription = this._eventsService.getEventDetails(eventId).subscribe({
      next: data => this.event = data,
      error: err => console.log(err)
    });
  }
  ngOnDestroy(): void {
    if (this._eventsServiceSubscription) this._eventsServiceSubscription.unsubscribe();
  }
}
