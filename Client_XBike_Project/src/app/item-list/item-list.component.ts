import { Component, OnInit } from '@angular/core';
import { ApiService } from "../api.service";

@Component({
  selector: 'app-item-list',
  templateUrl: './item-list.component.html',
  styleUrls: ['./item-list.component.css']
})
export class ItemListComponent implements OnInit {

  bicicletas: any = [];

  constructor(private apiService: ApiService) { }

  ngOnInit(): void {
    this.apiService.getIBicicletas().subscribe(data => {
      this.bicicletas = data;
    });
  }
}
