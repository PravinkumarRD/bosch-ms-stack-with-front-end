import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { Observable } from "rxjs";

import { Event } from "../models/event";

@Injectable()
export class EventsService {
  constructor(private _httpClient: HttpClient) {

  }
  //private _baseUrl: string = "http://localhost:9090/api";//Node JS API
  private _baseUrl: string="https://localhost:7097/api";
  getAllEvents(): Observable<Event[]> {
    return this._httpClient.get<Event[]>(`${this._baseUrl}/BoschEvents`);
  }
  getEventDetails(eventId:number): Observable<Event> {
    return this._httpClient.get<Event>(`${this._baseUrl}/BoschEvents/${eventId}`);
  }
}
