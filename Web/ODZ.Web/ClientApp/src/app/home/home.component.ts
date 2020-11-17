import { Component, OnInit } from '@angular/core';
import { ArticleService } from '../../_services/article.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent implements OnInit {
  public articles = [];
  public loading: boolean;
  constructor(private articleService: ArticleService) { this.articles = []; }

  ngOnInit(): void {
    this.loading = true;
    this.getAllArticles();
  }

  getAllArticles(): void {
    this.articleService.getAll()
      .subscribe(success => {
        if (success) {
          this.articles = this.articleService.articles;
        }
        this.loading = false;
      })
  }
}
