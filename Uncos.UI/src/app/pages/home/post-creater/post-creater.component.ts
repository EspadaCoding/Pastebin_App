import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { Router } from '@angular/router' 
import { NewsToCreate } from '../../../models/NewsToCreate';

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
  constructor(  private router: Router,private http: HttpClient  ) { }
  
  ngOnInit() {  
    
    } 

    createNews() {
      this.news = {
        title: this.title,
        content: this.discription, 
        poster:this.response?.dbPath  
      } 
       console.log("News Poster => "+this.news.poster);
       console.log("News title => "+this.news.title);
       console.log("News content => "+this.news.content);
      // this.http.post('https://localhost:44362/api/v1/News/Create', this.news)
      // .subscribe(res => { 
      // }); 
      

      this.title = '';
      this.discription = ''; 
      console.log(this.news.poster); 
      this.router.navigate(['/home']);
    }

    
   public uploadFinished = (event) => {   
    this.response = event;
   }

    Back()
    {
      this.router.navigate(['/home']);
    } 

}