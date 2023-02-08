import { Injectable } from '@angular/core';
import { ApiService } from './api.service';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  private readonly route = 'user';

  constructor(private readonly apiService: ApiService) { }

  getAllUsers(id = {}) {
    return this.apiService.get(this.route);
  }

  deleteUser(userId: string): Observable<any> {
    return this.apiService.delete(`${this.route}/${userId}`);
  }
}
