import { Component, OnInit } from '@angular/core';
import { UserService } from '../../../core/services/user.service';
import { User } from '../../../data/interfaces/user';

@Component({
  selector: 'app-users',
  templateUrl: './users.component.html',
  styleUrls: ['./users.component.css']
})
export class UsersComponent implements OnInit {
  public users: Array<User> = [];

  constructor(private readonly userService: UserService) {}

  ngOnInit(): void {
    this.userService.getAllUsers().subscribe((data: Array<User>) => this.users = data); 
  }

  deleteUser(userID: string) {
    this.userService.deleteUser(userID).subscribe((data: any) => this.users = data);
  }

}