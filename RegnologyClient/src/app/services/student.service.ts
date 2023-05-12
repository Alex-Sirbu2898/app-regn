import { Injectable } from "@angular/core";

import { HttpClient, HttpErrorResponse } from '@angular/common/http';

import { Observable, throwError,  } from 'rxjs';
import { map, catchError } from 'rxjs/operators';

import { environment } from "src/environments/environment";
import { Employee } from "../models/employee";
import { formatQueryString } from "../utils/format-filter-query";

@Injectable({
    providedIn:'root'
})
export class EmployeeService{
    baseUrl = environment.apiUrl + '/' + 'employee'

    constructor(private http: HttpClient) { }
    
    getemployee(id?:number) : Observable<Employee> {
        return this.http.get<Employee>(this.baseUrl + '/'+id)
            .pipe(
                   map(employee => 
                       employee
                   ),
                   catchError(this.handleError)
                );
    }

    filterEmployees(filterQuery: string): Observable<Array<Employee>>{
        const queryString = formatQueryString(filterQuery);

        return this.http
        .get<Array<Employee>>(
            `${this.baseUrl}/filter${queryString}`
        )
        .pipe(
            map((response) => response),
            catchError(this.handleError)
        );
    }

    addEmployee(model: Employee) : Observable<Employee> {
        return this.http.post<Employee>(this.baseUrl, model)
            .pipe(
                   map(employee => 
                       employee
                   ),
                   catchError(this.handleError)
                );
    }

    editEmployee(model: Employee) : Observable<Employee> {
        return this.http.put<Employee>(this.baseUrl, model)
            .pipe(
                   map(employee => 
                       employee
                   ),
                   catchError(this.handleError)
                );
    }

    deleteEmployee(id: number) {
        return this.http.delete(
            `${this.baseUrl}/${id}`
        );
    }


    protected handleError(error: HttpErrorResponse) {
        console.error('server error:', error); 
        if (error.error instanceof Error) {
          let errMessage = error.error.message;
          return throwError(() => new Error(errMessage));
        }
        return throwError(() => new Error(error.message));
    }
}