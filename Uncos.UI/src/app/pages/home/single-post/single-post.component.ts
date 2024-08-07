import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { News } from '../../../models/News';
import { NewsService } from '../../../services/news.service';

@Component({
  selector: 'app-single-post',
  templateUrl: './single-post.component.html',
  styleUrl: './single-post.component.css'
})
 
export class SinglePostComponent {
  id!: number;
  news:News;
  constructor(private router: Router, private route: ActivatedRoute, private newsService: NewsService) { }

  ngOnInit(): void {
    this.id = this.route.snapshot.params['id']; 
    this.newsService.find(this.id).subscribe((data) => {
      this.news = data as News;
    })
  }
}
