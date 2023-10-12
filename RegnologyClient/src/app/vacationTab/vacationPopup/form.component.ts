import { Component, Input, OnInit } from "@angular/core";
import { VacationDays } from "src/app/models/vacation";
import { VacationService } from "src/app/services/vacation.service";

@Component({
    selector: 'employee-form',
    templateUrl: './form.component.html',
    styleUrls: ['./form.component.css'],
})
export class employeeFormComponent implements OnInit{
    @Input()
    public entityId?: number;

    minDate: Date = new Date(Date.now());
    maxDate: Date = new Date(2005,1,1);

    genderValues!: any; 
    majorValues!: any;

    public model!: VacationDays;
    protected dataService!: VacationService;

    constructor(
        dataService: VacationService
    ){
        this.dataService = dataService;
    }

    ngOnInit(): void {
        this.initializeSelectedItem(this.entityId);
  
    }
    
    initializeSelectedItem(id?: number){
        if(id && id > 0){
            this.getItem(id);
            return;
        }

        if(!this.model)
            this.model = new VacationDays();
    }
    public getItem(id?: number){
        this.dataService.getVacation(id)
        .subscribe((response) => this.model = response),
        (err: any) => console.log(err);
    }

    saveData(){
        this.insert();
    }

    insert(){
        this.dataService.addVacation(this.model).subscribe();
        }
}
