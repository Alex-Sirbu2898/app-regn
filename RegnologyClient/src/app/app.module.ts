import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { InputTextModule } from 'primeng/inputtext';
import { TableModule} from 'primeng/table';
import { CalendarModule } from 'primeng/calendar';
import { ContextMenuModule} from 'primeng/contextmenu';
import { BrowserAnimationsModule} from '@angular/platform-browser/animations';
import {ButtonModule} from 'primeng/button';
import {DynamicDialogModule} from 'primeng/dynamicdialog';
import { DialogModule} from 'primeng/dialog'
import {ToastModule} from 'primeng/toast';
import {ToolbarModule} from 'primeng/toolbar';
import {DropdownModule} from 'primeng/dropdown';


import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { StudentFormComponent } from './form/form.component';
import { StudentListComponent } from './list/list.component';
import { MessageService } from 'primeng/api';

@NgModule({
  declarations: [
    AppComponent,
    StudentFormComponent,
    StudentListComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    InputTextModule,
    FormsModule,
    HttpClientModule,
    TableModule,
    CalendarModule,
    ContextMenuModule,
    BrowserAnimationsModule,
    BrowserModule,
    ButtonModule,
    DynamicDialogModule,
    DialogModule,
    ToastModule,
    ToolbarModule,
    DropdownModule
  ],
  providers: [MessageService],
  bootstrap: [AppComponent]
})
export class AppModule { }
