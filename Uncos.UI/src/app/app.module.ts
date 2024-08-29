import { NgModule } from '@angular/core';
import { BrowserModule, provideClientHydration } from '@angular/platform-browser';
 
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { FormsModule } from '@angular/forms';
import { LoginComponent } from './pages/login/login.component';
import { HomeComponent } from './pages/home/home.component';
import { HTTP_INTERCEPTORS, HttpClientModule } from '@angular/common/http';
import { PostCreaterComponent } from './pages/home/post-creater/post-creater.component';
import { SinglePostComponent } from './pages/home/single-post/single-post.component';
import { HeaderComponent } from './layout/header/header.component';
import { FooterComponent } from './layout/footer/footer.component';  
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { AuthInterceptor } from './services/auth.interceptor'; 
import { UploadComponent } from './pages/home/upload/upload.component';
import { CommonModule } from '@angular/common';
import { PostEditComponent } from './pages/home/post-edit/post-edit.component';
 
@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    HomeComponent,
    PostCreaterComponent,
    SinglePostComponent,
    HeaderComponent,
    FooterComponent,
    UploadComponent, 
    PostEditComponent
  ],
  imports: [
    CommonModule,
    BrowserModule,
    FormsModule,
    AppRoutingModule ,
    HttpClientModule,
    FontAwesomeModule
  ],
  providers: [
    provideClientHydration(),
    {
      provide: HTTP_INTERCEPTORS,
      useClass: AuthInterceptor,
      multi: true
    }
],
  bootstrap: [AppComponent]
})
export class AppModule { }
