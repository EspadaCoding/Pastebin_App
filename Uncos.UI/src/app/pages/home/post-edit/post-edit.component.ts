import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { NewsToCreate } from '../../../models/NewsToCreate';
import { Category } from '../../../models/Category';
import { CategoryService } from '../../../services/category.service';
import { TokenStorageService } from '../../../services/token-storage.service';
import { NewsService } from '../../../services/news.service';

@Component({
  selector: 'app-post-edit',
  templateUrl: './post-edit.component.html',
  styleUrl: './post-edit.component.css'
})
export class PostEditComponent implements OnInit { 
  public news: NewsToCreate;
  public title: string;
  public description: string;
  public response: { dbPath: '' };
  public categories: Category[] = [];
  public selectedCategory: Category;
  public postId: string;

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private http: HttpClient,
    private categoryService: CategoryService,
    private token: TokenStorageService,
    private newsService: NewsService
  ) {}

  ngOnInit() {
    this.postId = this.route.snapshot.paramMap.get('id'); 
  } 

  uploadFinished(event) {
    this.response = event;
  }
  updateNews() { 
  }
  Back() {
    this.router.navigate(['/home']);
  }
}
