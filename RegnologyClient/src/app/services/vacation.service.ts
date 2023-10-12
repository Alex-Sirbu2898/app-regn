import { Injectable } from "@angular/core";
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Observable, throwError,  } from 'rxjs';
import { map, catchError } from 'rxjs/operators';
import { environment } from "src/environments/environment";
import { VacationDays } from "../models/vacation";

@Injectable({
    providedIn:'root'
})
export class VacationService{
    baseUrl = environment.apiUrl + '/' + 'vacation'

    constructor(private http: HttpClient) { }
    
    getVacation(id?:number) : Observable<VacationDays> {
        return this.http.get<VacationDays>(this.baseUrl + '/'+id)
            .pipe(
                   map(vacation => 
                       vacation
                   ),
                   catchError(this.handleError)
                );
    }

    addVacation(model: VacationDays) : Observable<VacationDays> {
        return this.http.post<VacationDays>(this.baseUrl, model)
            .pipe(
                   map(vacation => 
                       vacation
                   ),
                   catchError(this.handleError)
                );
    }

    deleteVacation(id: number) {
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