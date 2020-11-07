import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './login/login.component';
import { NewsComponent } from './news/news.component';
import { PageNotFoundComponent } from './shared/page-not-found/page-not-found.component';

const routes: Routes = [
  { path: 'news', component: NewsComponent },
  { path: 'login', component: LoginComponent },
  { path: '', redirectTo: 'news', pathMatch: 'full' },
  { path: '**', component: PageNotFoundComponent }
];

@NgModule({   
  imports: [
    RouterModule.forRoot(routes, { enableTracing: false })
  ],
  declarations: [],
  providers: [],
  exports: [RouterModule]
})
export class AppRoutingModule { }
