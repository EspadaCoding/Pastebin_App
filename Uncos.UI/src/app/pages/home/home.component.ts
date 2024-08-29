import { Component } from '@angular/core';
import { TokenStorageService } from '../../services/token-storage.service';
import { NewsService } from '../../services/news.service';  
import { News } from '../../models/News'; 

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrl: './home.component.css'
})
export class HomeComponent { 
  currentUser: any;
    Allnews: News[] = [ ];  

  constructor(private token: TokenStorageService,
              private newsService: NewsService) { }

  ngOnInit(): void {  
    this.currentUser = this.token.getUser(); 
    this.fetchAllNews(); 
  }



  fetchAllNews(): void {
    this.newsService.getAll().subscribe(
      res => {
        console.log('Received data:', res);
  
        if (res && res.news && Array.isArray(res.news)) {
          const likedPosts = this.getSessionStorageArray('likedPosts');
          const savedPosts = this.getSessionStorageArray('savedPosts');
  
          this.Allnews = res.news.map((news: any) => ({
            ...news,
            createdDate: new Date(news.createdDate),
            itLiked: likedPosts.includes(news.id),
            itSaved: savedPosts.includes(news.id),
          }));
        } else {
          console.error('Unexpected data format:', res);
        }
  
        console.log('All news:', this.Allnews);
      },
      err => {
        console.error('Error fetching news:', err);
      }
    );
  } 
  createImgPath = (serverPath: string) => { 
    const modifiedPath = serverPath.replace('Resources', 'StaticFiles');
    return `https://localhost:44362/${modifiedPath}`;
  } 
  toggleLike(news: News): void {
    this.newsService.Likethis(news.id).subscribe({
      next: (response) => {
        console.log('Лайк успешно обновлен на сервере', response);
        news.itLiked = !news.itLiked; // Обновляем состояние в интерфейсе
  
        // Обновляем sessionStorage
        let likedPosts = JSON.parse(sessionStorage.getItem('likedPosts')) || [];
        if (news.itLiked) {
          likedPosts.push(news.id);
        } else {
          likedPosts = likedPosts.filter(id => id !== news.id);
        }
        sessionStorage.setItem('likedPosts', JSON.stringify(likedPosts));
      },
      error: (error) => {
        console.error('Ошибка при обновлении лайка', error);
      }
    });
  }
  toggleSave(news: News): void {
    this.newsService.SaveThis(news.id).subscribe({
        next: (response) => {
            console.log('Пост успешно сохранен/удален на сервере', response);
            news.itSaved = !news.itSaved; // Обновляем состояние в интерфейсе
  
            // Обновляем sessionStorage
            let savedPosts = JSON.parse(sessionStorage.getItem('savedPosts')) || [];
            if (news.itSaved) {
                savedPosts.push(news.id);
            } else {
                savedPosts = savedPosts.filter(id => id !== news.id);
            }
            sessionStorage.setItem('savedPosts', JSON.stringify(savedPosts));
        },
        error: (error) => {
            console.error('Ошибка при сохранении/удалении поста', error);
        }
    });
  }
  deleteNews(id:string){
    this.newsService.delete(id).subscribe(res => {
      this.Allnews = this.Allnews.filter(item => item.id !== id);
      console.log('Post deleted successfully!');
  })
  }



  private getSessionStorageArray(key: string): string[] {
    return JSON.parse(sessionStorage.getItem(key) || '[]');
  } 
} 
