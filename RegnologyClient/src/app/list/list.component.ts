import { Component, OnInit, ViewChild, ViewChildren } from '@angular/core';
import { Employee } from "../models/employee";
import { LazyLoadEvent } from 'primeng/api';
import { employeeFormComponent } from '../form/form.component';
import { Table } from 'primeng/table';
import { EmployeeService } from '../services/student.service';

@Component({
    templateUrl: './list.component.html'
})
export class employeeListComponent implements OnInit {
    employees!: Employee[];

    totalRecords!: number;

    loading!: boolean;

    selectedEmployee!: Employee;

    queryString: string = '';

    employeeDialog: boolean = false;
    @ViewChild('addOrEditForm') public form!: employeeFormComponent;

    @ViewChild('grid') public grid!: Table;

    constructor(
        private employeeService: EmployeeService
        ) { }

    ngOnInit() {
        this.loading = true;
        this.selectedEmployee = new Employee();

    }

    filteremployees(event: LazyLoadEvent) {
        this.loading = true;

        setTimeout(() => {
            this.employeeService.filterEmployees(this.queryString).subscribe(res => {
                this.employees = res;
                this.loading = false;
                this.totalRecords = res.length;
            })
        }, 1000);
    }



    onSelectionChange(event: { data: Employee; }) {
        this.selectedEmployee = event.data;
        console.log(this.selectedEmployee);
    }

    openNew() {
        this.selectedEmployee = new Employee();
        this.employeeDialog = true;
    }

    hideDialog() {
        this.employeeDialog = false;
        this.loading = true;
        setTimeout(() => {
            this.employeeService.filterEmployees(this.queryString).subscribe(res => {
                this.employees = res;
                this.loading = false;
                this.totalRecords = res.length;
            })
        }, 1000);    }

    editemployee(employee: Employee) {
        this.selectedEmployee = {...employee};
        this.employeeDialog = true;
    }

    saveEmployee(){
        debugger;
        if(typeof this.form !== 'undefined'){
            this.form.saveData();

            this.hideDialog();
        }
            return;
        }


    deleteEmployee(){
        if(this.selectedEmployee.id <= 0){
            return
        }

        this.employeeService.deleteEmployee(this.selectedEmployee.id).subscribe();

        this.hideDialog();
    }

    onRowSelect(event: any) {
        this.selectedEmployee = event.data;
        console.log(this.selectedEmployee);
    }

    onRowUnselect(event: any) {
        this.selectedEmployee = new Employee();
    }
}