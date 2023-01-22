import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

// Components
import { RegisterComponent } from './register/register.component';
import { LoginComponent } from './login/login.component';

// Modules
import { AuthRoutingModule } from './auth-routing.module';
import { MatListModule } from '@angular/material/list';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatInputModule } from '@angular/material/input';
import { MatCardModule } from '@angular/material/card';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';

@NgModule({
  declarations: [LoginComponent, RegisterComponent],
  imports: [
    CommonModule,
    AuthRoutingModule,
    CommonModule,
    MatListModule,
    ReactiveFormsModule,
    MatCardModule,
    MatFormFieldModule,
    MatIconModule,
    MatButtonModule,
    FormsModule,
    MatInputModule
  ]
})
export class AuthModule { }