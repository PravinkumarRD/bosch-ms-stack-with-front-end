import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { Observable } from "rxjs";

import { Employee } from "../models/employee";

@Injectable()
export class EmployeesService {
  constructor(private _httpClient: HttpClient) {

  }
  private _baseUrl: string = "http://localhost:9090/api";

  getAllEmployees(): Observable<Employee[]> {
    return this._httpClient.get<Employee[]>(`${this._baseUrl}/employees`);
  }
  getEmployeeDetails(employeeId:number): Observable<Employee> {
    return this._httpClient.get<Employee>(`${this._baseUrl}/employees/${employeeId}`);
  }
}