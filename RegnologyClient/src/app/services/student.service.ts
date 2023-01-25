import { Injectable } from "@angular/core";

import { HttpClient, HttpErrorResponse } from '@angular/common/http';

import { Observable, throwError,  } from 'rxjs';
import { map, catchError } from 'rxjs/operators';

import { environment } from "src/environments/environment";
import { Student } from "../models/student";
import { formatQueryString } from "../utils/format-filter-query";

@Injectable({
    providedIn:'root'
})
export class StudentService{
    baseUrl = environment.apiUrl + '/' + 'student'

    constructor(private http: HttpClient) { }
    
    getStudent(id?:number) : Observable<Student> {
        return this.http.get<Student>(this.baseUrl + '/'+id)
            .pipe(
                   map(student => 
                       student
                   ),
                   catchError(this.handleError)
                );
    }

    filterStudents(filterQuery: string): Observable<Array<Student>>{
        const queryString = formatQueryString(filterQuery);

        return this.http
        .get<Array<Student>>(
            `${this.baseUrl}/filter${queryString}`
        )
        .pipe(
            map((response) => response),
            catchError(this.handleError)
        );
    }

    addStudent(model: Student) : Observable<Student> {
        return this.http.post<Student>(this.baseUrl, model)
            .pipe(
                   map(student => 
                       student
                   ),
                   catchError(this.handleError)
                );
    }

    editStudent(model: Student) : Observable<Student> {
        return this.http.put<Student>(this.baseUrl, model)
            .pipe(
                   map(student => 
                       student
                   ),
                   catchError(this.handleError)
                );
    }

    deleteStudent(id: number) {
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