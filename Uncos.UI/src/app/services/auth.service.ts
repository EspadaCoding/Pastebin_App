import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';

const AUTH_API = 'https://localhost:44362/api/Auth/';

const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' })
};

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  constructor(private http: HttpClient) { }

  login(loginObj: any): Observable<any> {
    return this.http.post(AUTH_API + 'login', loginObj, httpOptions);
  }

  register(signupObj: any): Observable<any> {
    return this.http.post(AUTH_API + 'register', signupObj, httpOptions);
  }
}