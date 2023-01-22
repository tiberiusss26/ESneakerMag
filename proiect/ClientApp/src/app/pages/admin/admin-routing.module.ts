import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { AdminDashboardComponent } from './admin-dashboard/admin-dashboard.component';
import { UsersComponent } from './users/users.component';
import { ShoesComponent } from './shoes/shoes.component';
import { UserComponent } from './user/user.component';
import { ShoeComponent } from './shoe/shoe.component';

const routes: Routes = [
  {
    path: "dashboard",
    component: AdminDashboardComponent,
    children: [
      {
        path: "shoes",
        component: ShoesComponent
      },
      {
        path: "users",
        component: UsersComponent
      }
      //,
      //{
      //  path: "add-course",
      //  component: AddCourseComponent
      //},
      //{
      //  path: "add-student",
      //  component: AddStudentComponent
      //},
      //{
      //  path: "add-students-in-course/:courseId",
      //  component: AddStudentsToCourseComponent
      //}
    ]
  },
  {
    path: "user/:id",
    component: UserComponent
  },
  {
    path: "shoe/:id",
    component: ShoeComponent
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AdminRoutingModule { }
 