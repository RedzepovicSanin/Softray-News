import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { AuthenticationService } from '../services/authentication.service';
import { NewsService } from './news.service';
import { News } from '../shared/models/news';
import { User } from '../shared/models/user';

@Component({
  selector: 'app-news',
  templateUrl: './news.component.html',
  styleUrls: ['./news.component.scss']
})
export class NewsComponent implements OnInit {
  news: News[] = [{
    id: 1, title: "Bumble’s new feature prevents bad actors from using ‘unmatch’ to hide from their victims", text: `Dating app Bumble announced today it’s changing how its “unmatch” feature works in an effort to better prioritize user safety. The change will make it more difficult for a bad actor or harasser to use the app’s unmatch feature in order to avoid having their conversation reported to Bumble’s safety team.

    Before, when either side of a match opted to unmatch the other, the conversation simply would disappear. This, however, could be used by a bad actor to leave a conversation before the victim of their harassment had a chance to report them.
    
    The change will eliminate that possibility. Following the update, when one user unmatches the other, the match and the chat with the other user will disappear for the person who does the unmatching.`, status: 0, dateInserted: new Date(), userCreated: null
  },
  {
    id: 2, title: "Startup fundraising is the most tangible gender gap. How can we overcome it?", text: `ear-in, year-out, the gender gap in venture capital investment continues to be a problem women founders face. While the gender gap in other areas (such as the number of women entering tech in general) may be on the right path, this disparity in funding seems to be stagnant. There has been little movement in the amount of VC dollars going to women-founded companies since 2012.

    In fintech, the problem is especially prominent: Women-founded fintechs have raised a meager 1% of total fintech investment in the last 10 years. This should come as no surprise, given that fintech combines two sectors traditionally dominated by men: finance and technology. Though by no means does this mean that women aren’t doing incredible work in the field and it’s only right that women founders receive their fair share of VC investment.`, status: 0, dateInserted: new Date(), userCreated: null
  },
  {
    id: 3, title: "Hyundai reportedly in talks to buy SoftBank-owned Boston Dynamics", text: `Boston Dynamics could be set to change hands once again, according to a new report from Bloomberg that cited “people familiar with the matter.”

    The deal would make Korean automaker Hyundai the third company in seven years to own the robotics firm, following sales to Google and SoftBank  Group. Boston Dynamics is well known inside and out the industry for making some of the most advanced robotics systems on the planet, including BigDog and the humanoid Atlas.
    
    We’ve reached out to Hyundai, Softbank and Boston Dynamics for comment and will update if any respond.
    
    Since becoming a part of SoftBank in 2017, however, Boston Dynamics has aggressively pushed to commercialize its products after a quarter century of being focused on military and research robotics. Its Spot robot went up for sale last year and has appeared in a wide range of different applications. Recent notable appearances include Ukraine’s Chernobyl, the NYPD and telemedicine.`, status: 0, dateInserted: new Date(), userCreated: null
  },
  {
    id: 4, title: "Decrypted: Grayshift raises $47M, Apple bugs under attack, video game maker hacked", text: `The election is over, but not without a hitch or two. Some voters in Georgia and Ohio had to use paper ballots after hand sanitizer leaked into voting machines — an unexpected casualty of the pandemic. And a slew of robocalls across a number of swing states urged voters to “stay safe and stay home,” in an effort to disenfranchise voters from going to the polls. With record voter turnout, there’s little evidence to show it worked.

    But we saw nothing like the hack-and-leak operations like we did four years ago, which delivered an “October surprise” that derailed the election for Hillary Clinton, despite winning the popular vote by three million votes.
    
    Government officials and cybersecurity firms said there were no significant or damaging cyberattacks during Election Day. One Homeland Security official called it “another Tuesday on the internet,” but conceded there was still cause for concern in the election aftermath.`, status: 0, dateInserted: new Date(), userCreated: null
  },
  {
    id: 5, title: "The PlayStation 4 will be able to play PlayStation 5 games remotely", text: `Well, isn’t this a nice little surprise? This morning some PlayStation 4 owners are reporting the sudden and unexpected arrival of a new “PS5 Remote Play” app. While the app doesn’t do much yet (the PS5 isn’t out yet, after all), it seems meant to let you keep a PlayStation 5 in one room and stream it to (and control it from) a PlayStation 4 in another.

    Now, that’s not quite the same as actually having another PS5 in that second room; Remote Play tends to introduce a little bit of lag into the mix, so you probably won’t want to turn to it for twitchy games where every millisecond counts. But given that last-gen’s console tends to eventually find itself gathering dust or tucked into another room as a wildly overpowered Blu-ray/Netflix player, this is a pretty great way to extend the PS4’s lifespan. IGN spotted the app this morning, and it appears to be rolling out to users in batches`, status: 0, dateInserted: new Date(), userCreated: null
  }];
  user: User = null;
  
  constructor(
    private newsService: NewsService,
    private authenticationService: AuthenticationService,
    private toastrService: ToastrService
  ) {
  }

  ngOnInit() {
    this.user = JSON.parse(localStorage.getItem('user'))
    this.newsService.getLatestNews().subscribe((response: User[]) => {
      console.log(response);
    }, err => {
      this.toastrService.error(err.error);
    });
  }

  logout() {
    this.authenticationService.logout();
    this.user = null;
  }
}
