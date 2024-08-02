import { Injectable } from '@angular/core';
import { Observable } from "rxjs";
import { HttpClient } from "@angular/common/http";

import { AuthResponse } from "../models/auth-response";
import { User } from "../models/user";

@Injectable({
  providedIn: 'root'
})
export class SecurityService {
  constructor(private _httpClient: HttpClient) {

  }
  //private _baseUrl:string="http://localhost:9090/api";
  private _baseUrl: string = "https://localhost:7097/api";
  authenticateCredentials(user: User): Observable<AuthResponse> {
    return this._httpClient.post<AuthResponse>(`${this._baseUrl}/BoschUsers/Credentials`, { userName: user.email, password: user.password }, {
      headers: {
        "Content-Type": "application/json"
      }
    })
  }
}
