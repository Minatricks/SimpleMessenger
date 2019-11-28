import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { SingInComponent } from './user/components/sing-in/sing-in.component';
import { AppComponent } from './app.component';
import { MessageViewComponent } from './main-view/main-view/message-view.component';
import { MenuComponent } from './user/components/menu/menu.component';
import { SingUpComponent } from './user/components/sing-up/sing-up.component';

const childLoginMenuRoutes: Routes = [
  {
    path: 'sign-in', component: SingInComponent
  },
  {
    path: 'sign-up', component: SingUpComponent
  }
];

const routes: Routes = [
  {
    path: 'login', component: MenuComponent, children: childLoginMenuRoutes,
  },
  {
    path: 'message', component: MessageViewComponent
  },
  {
    path: '**', redirectTo: '/login'
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule {

}
