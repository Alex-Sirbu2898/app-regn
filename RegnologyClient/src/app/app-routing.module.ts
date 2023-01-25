import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { StudentFormComponent } from './form/form.component';
import { StudentListComponent } from './list/list.component';

const routes: Routes = [
    {
      path:'',
      redirectTo:'list',
      pathMatch: 'full',
    },
    {
      path: 'list',
      component: StudentListComponent,
    },
    {
        path: 'edit/:id',
        component: StudentFormComponent
    }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
