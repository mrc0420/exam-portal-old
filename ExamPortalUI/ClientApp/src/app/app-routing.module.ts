import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AdmincontrolsComponent } from './admincontrols/admincontrols.component';


const routes: Routes = [
  { path: "admin", component: AdmincontrolsComponent }];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
