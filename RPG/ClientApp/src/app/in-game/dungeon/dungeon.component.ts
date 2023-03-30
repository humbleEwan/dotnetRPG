import { HttpClient } from '@angular/common/http';
import { Component, Inject } from '@angular/core';

@Component({
  selector: 'app-dungeon',
  templateUrl: './dungeon.component.html',
})
export class DungeonComponent {

  public enemyName: string = "__default__";
  public encounterHash: string = "__default__";
  public enemyHP: string = "__NONE__";

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    console.log(baseUrl + 'dungeon/roll');
    http.get<IEncounter>(baseUrl + 'dungeon/roll').subscribe(result => {
      console.log(result);
      this.enemyName = result.enemyName;
      this.encounterHash = result.hash;
      this.enemyHP = result.hp.toString();
    })
  }
}

interface IEncounter {
  enemyName: string;
  hash: string;
  hp: number;
}
