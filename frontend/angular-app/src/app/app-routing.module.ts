import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LoginComponent } from './login/login.component';
import { ChatoverviewComponent } from './chatoverview/chatoverview.component';

const routes: Routes = [
  { path:"login", component:LoginComponent},
  { path:"chatoverview", component: ChatoverviewComponent},
  { path: '**', component: LoginComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
