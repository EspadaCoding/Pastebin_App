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
  // news:News= {  
  //   id:  "043D3710-F7DC-4744-BA80-7264C16318BB",     
  //   userId:  "A89FD8BA-7BA4-462D-B30F-F2BFF960B173",
  //   title:"Antonia Banderes" ,
  //   content:  "qwertyuiopasdfghjklzxccvbnmregerger gtht jtyjtyqwertyuiopasdfghjklzxccvbnmregerger qwertyuiopasdfghjklzxccvbnmregerger qwertyuiopasdfghjklzxccvbnmregerger qwertyuiopasdfghjklzxccvbnmregerger qwertyuiopasdfghjklzxccvbnmregerger qwertyuiopasdfghjklzxccvbnmregerger qwertyuiopasdfghjklzxccvbnmregerger qwertyuiopasdfghjklzxccvbnmregerger qwertyuiopasdfghjklzxccvbnmregerger ",
  //   poster: "assets/img/blog-img/3.jpg" ,
  //   likes: 15,
  //   itSaved: false ,
  //   createdDate:  new Date(),
  //   categoryId:  "C3F7FEAC-84E2-4784-DC8E-08DC67C68989",
  //   countofComments: 0 ,
  // };

  constructor(private token: TokenStorageService,
              private newsService: NewsService) { }

  ngOnInit(): void {  
    this.fetchAllNews();
    this.currentUser = this.token.getUser(); 
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
} 
