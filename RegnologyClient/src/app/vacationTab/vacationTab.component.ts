import { Component, Input, OnInit } from "@angular/core";
import { CalendarModule } from 'primeng/calendar';

@Component({
    selector: 'employee-vacation',
    templateUrl: './form.component.html',
    styleUrls: ['./form.component.css'],
})
export class EmployeeVacationComponent implements OnInit{
    date!: Date[];
    @Input()
    public entityId?: number;

    ngOnInit(): void {
    }
  
}