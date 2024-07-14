import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';    
import { News } from '../models/News';

@Injectable({
  providedIn: 'root'
})
export class NewsService {

  private apiUrl = 'https://localhost:44362/api/v1/News'; // Base URL

  constructor(private httpClient: HttpClient) { }
  
   getAll(): Observable<{ news: News[] }> {
    return this.httpClient.get<{ news: News[] }>(`${this.apiUrl}/GetAllNews`);
  }

  find(id: number): Observable<News> { 
    return this.httpClient.get<News>(`${this.apiUrl}/GetUserNewsById/${id}`);
  }

  update(id: number, news: News): Observable<void> { 
    return this.httpClient.put<void>(`${this.apiUrl}/Update/${id}`, news);
  }
}