import { Component, Input, OnInit } from "@angular/core";
import { Student } from "../models/student";
import { StudentService } from "../services/student.service";
import {InputTextModule} from 'primeng/inputtext';
import { Gender } from "../models/gender";

@Component({
    selector: 'student-form',
    templateUrl: './form.component.html',
    styleUrls: ['./form.component.css'],
})
export class StudentFormComponent implements OnInit{
    @Input()
    public entityId?: number;

    minDate: Date = new Date(1988,1,1);
    maxDate: Date = new Date(2005,1,1);

    genderValues!: any; 
    majorValues!: any;

    public model!: Student;
    protected dataService!: StudentService;

    constructor(
        dataService: StudentService
    ){
        this.dataService = dataService;
    }

    ngOnInit(): void {
        this.populateDropdown();
        this.initializeSelectedItem(this.entityId);
  
    }

    public getItem(id?: number){
        this.dataService.getStudent(id)
        .subscribe((response) => this.model = response),
        (err: any) => console.log(err);
    }

    saveData(){
        debugger;
        if(this.model.id > 0){
            this.update();
            return;
        }

        this.insert();
    }

    insert(){
        this.dataService.addStudent(this.model).subscribe();
        }

    update(){
        this.dataService.editStudent(this.model).subscribe();
        } 

        initializeSelectedItem(id?: number){
            if(id && id > 0){
                this.getItem(id);
                return;
            }

            if(!this.model)
                this.model = new Student();
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
