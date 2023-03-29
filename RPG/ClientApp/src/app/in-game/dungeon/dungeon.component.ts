import { HttpClient } from '@angular/common/http';
import { Component, Inject } from '@angular/core';

@Component({
  selector: 'app-dungeon',
  templateUrl: './dungeon.component.html',
})
export class DungeonComponent {

  public enemy: string = "__default__";

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    console.log(baseUrl + 'dungeon');
    http.get<string>(baseUrl + 'dungeon').subscribe(result => {
      console.log(result);
      this.enemy = result;
    })
  }
}
