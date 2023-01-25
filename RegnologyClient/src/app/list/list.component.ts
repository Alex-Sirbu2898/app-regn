import { Component, OnInit, ViewChild, ViewChildren } from '@angular/core';
import { Student } from "../models/student";
import { StudentService } from "../services/student.service";
import { LazyLoadEvent } from 'primeng/api';
import { StudentFormComponent } from '../form/form.component';
import { Table } from 'primeng/table';

@Component({
    templateUrl: './list.component.html'
})
export class StudentListComponent implements OnInit {
    students!: Student[];

    totalRecords!: number;

    loading!: boolean;

    selectedStudent!: Student;

    queryString: string = '';

    studentDialog: boolean = false;
    @ViewChild('addOrEditForm') public form!: StudentFormComponent;

    @ViewChild('grid') public grid!: Table;

    constructor(
        private studentService: StudentService
        ) { }

    ngOnInit() {
        this.loading = true;
        this.selectedStudent = new Student();

    }

    filterStudents(event: LazyLoadEvent) {
        this.loading = true;

        setTimeout(() => {
            this.studentService.filterStudents(this.queryString).subscribe(res => {
                this.students = res;
                this.loading = false;
                this.totalRecords = res.length;
            })
        }, 1000);
    }



    onSelectionChange(event: { data: Student; }) {
        this.selectedStudent = event.data;
        console.log(this.selectedStudent);
    }

    openNew() {
        this.selectedStudent = new Student();
        this.studentDialog = true;
    }

    hideDialog() {
        this.studentDialog = false;
        this.loading = true;
        setTimeout(() => {
            this.studentService.filterStudents(this.queryString).subscribe(res => {
                this.students = res;
                this.loading = false;
                this.totalRecords = res.length;
            })
        }, 1000);    }

    editStudent(student: Student) {
        this.selectedStudent = {...student};
        this.studentDialog = true;
    }

    saveStudent(){
        debugger;
        if(typeof this.form !== 'undefined'){
            this.form.saveData();

            this.hideDialog();
        }
            return;
        }


    deleteStudent(){
        if(this.selectedStudent.id <= 0){
            return
        }

        this.studentService.deleteStudent(this.selectedStudent.id).subscribe();

        this.hideDialog();
    }

    onRowSelect(event: any) {
        this.selectedStudent = event.data;
        console.log(this.selectedStudent);
    }

    onRowUnselect(event: any) {
        this.selectedStudent = new Student();
    }
}