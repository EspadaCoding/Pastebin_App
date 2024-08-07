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
    if (this.tokenStorage.getToken()) {
      this.isLoggedIn = true; 
    }
  }



  async onSignUp() {   
    try {
      const data = await this.authService.register(this.signupObj).toPromise();
      this.handleSuccess(data);
    } catch (err) {
      this.handleError(err);
    }
  }
  
  handleSuccess(data) {
    console.log(data);
    this.tokenStorage.saveToken(data.token);
    this.tokenStorage.saveUser(data.username);
    this.isSuccessful = true;
    this.isSignUpFailed = false;
    this.clearData(); 
    this.router.navigate(['/home']);
  } 
  handleError(err) {
    this.errorMessage = err.error.message;
    this.isSignUpFailed = true;
    this.clearData(); 
    this.reloadPage();
    console.log("Error => " + this.errorMessage);
  }


  async onLogin() {
    try {
      const data = await this.authService.login(this.loginObj).toPromise();
      this.handleLoginSuccess(data);
    } catch (err) {
      this.handleLoginError(err);
    }
  }
  
  handleLoginSuccess(data) {
    this.tokenStorage.saveToken(data.token);
    this.tokenStorage.saveUser(data.username);
    this.isLoginFailed = false;
    this.isLoggedIn = true; 
    this.clearData();  
    this.router.navigate(['/home']);
  }
  
  handleLoginError(err) {
    this.errorMessage = err.error.message;
    this.isLoginFailed = true;
    this.clearData(); 
    this.reloadPage();
    console.log("Error => " + this.errorMessage);
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