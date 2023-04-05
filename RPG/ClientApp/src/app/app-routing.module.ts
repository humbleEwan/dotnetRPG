import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { LoginComponent } from './home/login/login.component';
import { RegistrationComponent } from './home/register/registration.component';
import { DungeonComponent } from './in-game/dungeon/dungeon.component';

const routes: Routes = [
  { path: '', redirectTo: 'home', pathMatch: 'full' },
  {
    path: 'home',
    component: HomeComponent,
    children: [
      { path: 'login', component: LoginComponent },
      { path: 'register', component: RegistrationComponent },
      { path: '**', component: DungeonComponent },
    ],
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule {}
