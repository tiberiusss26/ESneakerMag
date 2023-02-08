import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { JwtModule } from '@auth0/angular-jwt';


import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { AppRoutingModule } from './app-routing.module';
import { AdminModule } from './pages/admin/admin.module';
import { AuthModule } from './pages/auth/auth.module';

export function tokenGetter() {
  console.log(localStorage.getItem('token'))
  return localStorage.getItem('token');
}

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    BrowserAnimationsModule,
    RouterModule,
    AppRoutingModule,
    AdminModule,
    AuthModule
    ,
    JwtModule.forRoot({
      config: {
        tokenGetter: tokenGetter,
        allowedDomains: ['localhost:1200', 'localhost:4200', 'localhost:5071', 'localhost:7121', 'localhost:23792', 'localhost:44410','localhost:48394', 'https://localhost:44410', 'http://localhost:48394']
      }
    })
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }