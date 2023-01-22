import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

//Components
import { AdminDashboardComponent } from './admin-dashboard/admin-dashboard.component';
import { ShoesComponent } from './shoes/shoes.component';
import { UsersComponent } from './users/users.component';
import { UserComponent } from './user/user.component';
import { ShoeComponent } from './shoe/shoe.component';

//Material Modules
import { MatListModule } from '@angular/material/list';
import { AuthRoutingModule } from '../auth/auth-routing.module';
import { RouterModule } from '@angular/router';
import { AppRoutingModule } from '../../app-routing.module';
import { AdminRoutingModule } from './admin-routing.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatCardModule } from '@angular/material/card';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';
import { MatInput, MatInputModule } from '@angular/material/input';



@NgModule({
  declarations: [AdminDashboardComponent, ShoesComponent, UsersComponent, UserComponent, ShoeComponent],
  imports: [
    CommonModule,
    MatListModule,
    AdminRoutingModule,
    ReactiveFormsModule,
    MatCardModule,
    MatFormFieldModule,
    MatIconModule,
    MatButtonModule,
    FormsModule,
    MatInputModule,
    AuthRoutingModule,
    RouterModule,
  ]
})
export class AdminModule { }
