import { Component, OnInit, OnDestroy, AfterViewInit, ViewChild } from '@angular/core';
import { MatPaginator, MatPaginatorModule } from '@angular/material/paginator';
import { MatSort, Sort, MatSortModule } from '@angular/material/sort';
import { MatTableDataSource, MatTableModule } from '@angular/material/table';
import { Subscription } from "rxjs";

import { Employee } from "../../models/employee";

import { EmployeesService } from '../../services/employees.service';
@Component({
  selector: 'bosch-employees-list',
  standalone: true,
  imports: [MatTableModule, MatPaginatorModule, MatSortModule],
  templateUrl: './employees-list.component.html',
  styleUrl: './employees-list.component.css',
  providers: [EmployeesService]
})
export class EmployeesListComponent implements OnInit, AfterViewInit, OnDestroy {
  constructor(private _employeesService: EmployeesService) {

  }

  title: string = "Welcome To Bosch Employees List!";
  subTitle: string = "Core Development Team of Bosch India!";
  displayedColumns: string[] = ['employeeName', 'city', 'email', 'phone'];
  dataSource = new MatTableDataSource<Employee>([]);
  employees: Employee[];
  @ViewChild(MatPaginator) paginator: MatPaginator;
  @ViewChild(MatSort) sort: MatSort;
  private _employeesServiceSubscription: Subscription;
  ngOnInit(): void {
    this._employeesServiceSubscription = this._employeesService.getAllEmployees().subscribe({
      next: data => this.dataSource.data = data,
      error: err => console.log(err)
    });
  }
  ngAfterViewInit(): void {
    this.dataSource.paginator = this.paginator;
    this.dataSource.sort = this.sort;
  }
  ngOnDestroy(): void {
    if (this._employeesServiceSubscription) this._employeesServiceSubscription.unsubscribe();
  }
}
