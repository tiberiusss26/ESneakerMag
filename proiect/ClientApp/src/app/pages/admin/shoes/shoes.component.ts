import { Component, OnInit } from '@angular/core';
import { ShoeService } from '../../../core/services/shoe.service';
import { Shoe } from '../../../data/interfaces/shoe';

@Component({
  selector: 'app-shoes',
  templateUrl: './shoes.component.html',
  styleUrls: ['./shoes.component.css']
})
export class ShoesComponent implements OnInit {

  public shoes: Array<Shoe> = [];

  constructor(private readonly shoeService: ShoeService) { }

  ngOnInit(): void {
    this.shoeService.getAllShoes().subscribe((data: Array<Shoe>) => this.shoes = data);
  }
}