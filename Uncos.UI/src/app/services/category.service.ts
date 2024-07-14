import { Injectable } from '@angular/core'; 
import { HttpClient, HttpHeaders } from '@angular/common/http'; 
import {  Observable, throwError } from 'rxjs';
import { Category } from '../models/Category';

@Injectable({
  providedIn: 'root'
})
export class CategoryService {

  constructor(private httpClient: HttpClient) { }
      

  getAll(): Observable<Category[]> { 
    return this.httpClient.get<Category[]>('https://localhost:44362/api/v1/Category/GetAll') ;
  }
  
}