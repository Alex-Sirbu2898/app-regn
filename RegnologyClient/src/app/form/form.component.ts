import { Component, Input, OnInit } from "@angular/core";
import { Employee } from "../models/employee";
import {InputTextModule} from 'primeng/inputtext';
import { Gender } from "../models/gender";
import { EmployeeService } from "../services/student.service";

@Component({
    selector: 'employee-form',
    templateUrl: './form.component.html',
    styleUrls: ['./form.component.css'],
})
export class employeeFormComponent implements OnInit{
    @Input()
    public entityId?: number;

    minDate: Date = new Date(1988,1,1);
    maxDate: Date = new Date(2005,1,1);

    genderValues!: any; 
    majorValues!: any;

    public model!: Employee;
    protected dataService!: EmployeeService;

    constructor(
        dataService: EmployeeService
    ){
        this.dataService = dataService;
    }

    ngOnInit(): void {
        this.populateDropdown();
        this.initializeSelectedItem(this.entityId);
  
    }

    public getItem(id?: number){
        this.dataService.getemployee(id)
        .subscribe((response) => this.model = response),
        (err: any) => console.log(err);
    }

    saveData(){
        if(this.model.id > 0){
            this.update();
            return;
        }

        this.insert();
    }

    insert(){
        this.dataService.addEmployee(this.model).subscribe();
        }

    update(){
        this.dataService.editEmployee(this.model).subscribe();
        } 

        initializeSelectedItem(id?: number){
            if(id && id > 0){
                this.getItem(id);
                return;
            }

            if(!this.model)
                this.model = new Employee();
        }

        populateDropdown(){
            this.genderValues = [
                {name: 'Male', value: 0},
                {name: 'Female', value:1}
            ];       
            
            this.majorValues = [
                {name: 'Computer Science', value: 1},
                {name: 'Law', value:2},
                {name: 'Engineer', value:3},
                {name: 'Business Administration', value:4}
            ];  
        }
}
