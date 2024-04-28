import { Component } from '@angular/core';
import { AuthService } from '../../services/auth.service';
import { TokenStorageService } from '../../services/token-storage.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent {
  isSuccessful = false;
  isSignUpFailed = false; 
  isLoggedIn = false;
  isLoginFailed = false;
  errorMessage = '';
  roles: string[] = [];
    signupObj:any = {
         userName: '',
         email: '',
         password: '',
      }; 
      
    loginObj: any = {
    userName: '',
    password: '',
      };

  constructor(private authService: AuthService, private tokenStorage: TokenStorageService) { }
     ngOnInit(): void {
     } 
     onSignUp() {  
      this.authService.register(this.signupObj).subscribe(
        data => {
          console.log(data);
          this.isSuccessful = true;
          this.isSignUpFailed = false;
        },
        err => {
          this.errorMessage = err.error.message;
          this.isSignUpFailed = true;
        }
      ); 
      this.clearData();
     } 
     onLogin() {
      this.authService.login(this.loginObj).subscribe(
        data => {
          this.tokenStorage.saveToken(data.accessToken);
          this.tokenStorage.saveUser(data);
  
          this.isLoginFailed = false;
          this.isLoggedIn = true;
          this.roles = this.tokenStorage.getUser().roles;
          this.reloadPage();
        },
        err => {
          this.errorMessage = err.error.message;
          this.isLoginFailed = true;
        }
      );
      this.clearData();
    } 
    clearData(): void {
      this.signupObj = {
        userName:'',
        email: '',
        password:'',
        };
        this.loginObj={
          userName:'', 
          password:'',
        };
    }
    reloadPage(): void {
      window.location.reload();
    }
  }