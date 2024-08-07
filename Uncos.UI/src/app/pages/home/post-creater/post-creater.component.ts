import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Component } from '@angular/core';
import { Router } from '@angular/router' 
import { NewsToCreate } from '../../../models/NewsToCreate';
import { Category } from '../../../models/Category';
import { CategoryService } from '../../../services/category.service';
import { TokenStorageService } from '../../../services/token-storage.service';

@Component({
  selector: 'app-post-creater',
  templateUrl: './post-creater.component.html',
  styleUrl: './post-creater.component.css'
})
export class PostCreaterComponent {
  public news: NewsToCreate; 
  public title: string;
  public discription: string;  
  public posterPath: string;
  public response: {dbPath: ''};    
  public categories: Category[] = [];
  public selectedCategory: Category;
  //public currentUser: any;



  constructor(  private router: Router,
                private http: HttpClient,
                private categoryService:CategoryService,
                private token: TokenStorageService  ) { }
  
  ngOnInit() {  
    this.categoryService.getAll().subscribe((data) => {
      this.categories = data;
      console.log("All Categories =>", this.categories);
    }, error => {
      console.error("Error loading categories:", error);
    });
    } 

    createNews() {
      // Проверка на наличие всех обязательных полей
      if (!this.title || !this.discription || !this.selectedCategory?.id  ) {
        console.error('Missing required fields');
        return;
      }
    
      // Получение имени пользователя из sessionStorage 
      const username = this.token.getUser();
    
      if (!username) {
        console.error('User is not logged in');
        return;
      }
    
      this.news = {
        title: this.title,
        content: this.discription, 
        poster: this.response?.dbPath,  
        username: username,
        categoryid: this.selectedCategory.id
    
      };
    
      // Логирование данных перед отправкой
      console.log("News Data:", this.news);
    
      const httpOptions = {
        headers: new HttpHeaders({ 'Content-Type': 'application/json' })
      };
    
      this.http.post('https://localhost:44362/api/v1/News/Create', this.news, httpOptions)
        .subscribe(
          res => {
            console.log('News created successfully:', res);
            // Сброс полей формы после успешного создания новости
            this.title = '';
            this.discription = '';
            this.router.navigate(['/home']);
          },
          err => {
            console.error('Error creating news:', err);
            // Логирование полного ответа сервера для диагностики
            console.error('Server response:', err.error);
          }
        );
    }
    
    

    
   public uploadFinished = (event) => {   
    this.response = event;
   }

    Back()
    {
      this.router.navigate(['/home']);
    } 

}