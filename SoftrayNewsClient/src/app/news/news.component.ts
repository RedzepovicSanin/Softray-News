import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { News } from '../shared/models/news';
import { NewsService } from './news.service';

@Component({
  selector: 'app-news',
  templateUrl: './news.component.html',
  styleUrls: ['./news.component.scss']
})
export class NewsComponent implements OnInit {
  news: News[];
  constructor(
    private newsService: NewsService,
    private toastrService: ToastrService
  ) {}

  ngOnInit() {
    this.newsService.getLatestNews().subscribe((response: News[]) => {
      this.news = response;
    }, err => {
      this.toastrService.error(err.error);
    });
  }

}
