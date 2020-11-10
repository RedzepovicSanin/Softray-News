import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { News } from '../shared/models/news';
import { environment } from 'src/environments/environment';
import { User } from '../shared/models/user';

@Injectable({
  providedIn: 'root'
})
export class NewsService {

  constructor(private http: HttpClient) { }

  getLatestNews() {
      return this.http.get<User[]>(environment.baseConfigUrl + 'Users/GetAllUsers');
  }

  insertNews(news: News) {
    return this.http.post<News>(environment.baseConfigUrl + 'News/Insert', news);
  }

  updateNews(news: News) {
    return this.http.put<News>(environment.baseConfigUrl + 'News/Update', news);
  }
}
