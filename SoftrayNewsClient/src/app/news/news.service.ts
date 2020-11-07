import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { News } from '../shared/models/news';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class NewsService {

  constructor(private http: HttpClient) { }

  getLatestNews() {
      return this.http.get<News[]>(environment.baseConfigUrl + 'News/GetAllNews');
  }
}
