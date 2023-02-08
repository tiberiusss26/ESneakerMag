import { Injectable } from '@angular/core';
import { ApiService } from './api.service';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ShoeService {

  private readonly route = 'shoe';

  constructor(private readonly apiService: ApiService) { }

  getAllShoes(id = {}) {
    return this.apiService.get(this.route);
  }
}
