import { Component } from '@angular/core';
import { TokenStorageService } from '../../services/token-storage.service';
import { NewsService } from '../../services/news.service';  
import { News } from '../../models/News';
import { faBookmark, faHeart } from '@fortawesome/free-solid-svg-icons';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrl: './home.component.css'
})
export class HomeComponent {
  faHeart = faHeart;
  faBookmark = faBookmark;
  currentUser: any;
    Allnews: News[] = [ ]; 

  constructor(private token: TokenStorageService,
              private newsService: NewsService) { }

  ngOnInit(): void {  
    this.currentUser = this.token.getUser(); 
    this.fetchAllNews();
    
  }
  fetchAllNews(): void {
    // Вызов метода getAll() из сервиса NewsService, который возвращает Observable с данными новостей
    this.newsService.getAll().subscribe(
      res => {
        // Логируем полученные данные, чтобы проверить их структуру и убедиться, что они получены правильно
        console.log('Received data:', res);
  
        // Проверяем, есть ли в ответе поле 'news' и является ли оно массивом
        if (res && res.news && Array.isArray(res.news)) {
          // Если условие выполнено, преобразуем данные и присваиваем их переменной Allnews
          this.Allnews = res.news.map((news: any) => ({
            ...news, // Распаковываем все свойства объекта news
            createdDate: new Date(news.createdDate) // Преобразуем строку даты в объект Date
          }));
        } else {
          // Если структура данных неожиданная, логируем ошибку
          console.error('Unexpected data format:', res);
        }
        
        // Логируем преобразованные данные, чтобы проверить их перед отображением
        console.log('All news:', this.Allnews);
      },
      err => {
        // Обработка ошибок при запросе к серверу, логируем ошибку для отладки
        console.error('Error fetching news:', err);
      }
    );
  }

  public createImgPath = (serverPath: string) => { 
    const modifiedPath = serverPath.replace('Resources', 'StaticFiles');
    return `https://localhost:44362/${modifiedPath}`;
   }

   public toggleLike(news: News) {
    news.itLiked = !news.itLiked;
  }
  public toggleSave(news: News) {
    news.itSaved = !news.itSaved;
  }

} 
