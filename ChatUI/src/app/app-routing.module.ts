import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { SingUpComponent } from './user/components/sing-up/sing-up.component';
import { SingInComponent } from './user/components/sing-in/sing-in.component';
import { AppComponent } from './app.component';

const routes: Routes = [
  { path: " ", component: AppComponent},
  { path: "sign-up", component: SingUpComponent},
  { path: "sign-in", component: SingInComponent},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { 
  
}
