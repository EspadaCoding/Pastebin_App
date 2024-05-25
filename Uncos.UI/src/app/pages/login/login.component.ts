import { Component } from '@angular/core';
import { AuthService } from '../../services/auth.service';
import { TokenStorageService } from '../../services/token-storage.service';
import { Router } from '@angular/router'; 
import { Login } from '../../models/Login';
import { SignUp } from '../../models/SignUp';

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
  signupObj:SignUp;  
  loginObj:Login;

  constructor(private router: Router,
              private authService: AuthService, 
              private tokenStorage: TokenStorageService)
   {
      this.loginObj =new Login();
      this.signupObj=new SignUp();
   } 
   ngOnInit(): void {
    // if (this.tokenStorage.getToken()) {
    //   this.isLoggedIn = true;
    //   this.roles = this.tokenStorage.getUser().roles;
    // }
  }



     onSignUp() {   
      this.authService.register(this.signupObj).subscribe(
        data => {
          console.log(data);
          this.isSuccessful = true;
          this.isSignUpFailed = false;
          this.clearData(); 
          this.router.navigate(['/home']);
        },
        err => {
          this.errorMessage = err.error.message;
          this.isSignUpFailed = true;
          this.clearData(); 
          this.reloadPage();
          alert("Error =>"+this.errorMessage);
        }
      ); 
 
       
     } 
     onLogin() {
      // this.authService.login(this.loginObj).subscribe(
      //   data => {
      //     this.tokenStorage.saveToken(data.token);
      //     this.tokenStorage.saveUser(data.name); 
      //     this.isLoginFailed = false;
      //     this.isLoggedIn = true;
      //     this.roles = this.tokenStorage.getUser().roles;
      //     this.clearData();  
      //     this.router.navigate(['/home']);
      //   },
      //   err => {
      //     this.errorMessage = err.error.message;
      //     this.isLoginFailed = true;
      //     this.clearData(); 
      //     this.reloadPage();
      //     alert("Error =>"+ this.errorMessage);
      //   }
      // );
      this.router.navigate(['/home']);
       
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