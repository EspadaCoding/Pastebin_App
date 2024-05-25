import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './pages/login/login.component';
import { HomeComponent } from './pages/home/home.component';
import { PostCreaterComponent } from './pages/home/post-creater/post-creater.component';
import { SinglePostComponent } from './pages/home/single-post/single-post.component';

const routes: Routes = [
  {path: '', redirectTo: 'login' , pathMatch: 'full'},
  {path: 'login', component: LoginComponent},
  {path: 'home', component: HomeComponent},
  {path:'post-creater', component:PostCreaterComponent  },
  {path:'single-post/:id', component: SinglePostComponent  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
