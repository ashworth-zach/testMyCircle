import { loginComponent } from './home/login/login.component';
import { registerComponent } from './home/register/register.component';
import { mainComponent } from './main/main.component';
import {CreateChannelComponent} from './channel/create-channel/create-channel.component';
import {JoinChannelComponent} from './channel/join-channel/join-channel.component';





import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
const routes: Routes = [
  { path: 'login',component: loginComponent },
  { path: 'register',component: registerComponent },
  { path: 'makechannel',component: CreateChannelComponent }, 
  { path: 'joinchannel',component: JoinChannelComponent },  
  { path: 'homepage',component: mainComponent },
  { path: '', pathMatch: 'full', redirectTo: '/login' },

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }