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

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) {
    http.get<IEncounter>(baseUrl + 'dungeon/rollEncounter').subscribe(result => {
      console.log(result);
      this.enemyName = result.enemyName;
      this.encounterHash = result.hash;
      this.enemyHP = result.hp.toString();
    })
  }

  useBasicAttack() {
    console.log('Player used basic attack!');
    const data = { actionUsed: 'basicAttack', encounterHash: this.encounterHash };
    console.log(data);
    this.http.post<any>(this.baseUrl + 'dungeon/rotateEncounter', data).subscribe(result => {
      console.log(result);
    });
  }

  useAbilityGuard() {
    console.log('Player used guard!');
    const data = { actionUsed: 'guard', encounterHash: this.encounterHash };
    console.log(data);
    this.http.post<any>(this.baseUrl + 'dungeon/rotateEncounter', data).subscribe(result => {
      console.log(result);
    });
  }
}

interface IEncounter { //should be in a separate file
  enemyName: string;
  hash: string;
  hp: number;
}

interface IAction {
  abilityUsed: string
  encounterHash: string
}
