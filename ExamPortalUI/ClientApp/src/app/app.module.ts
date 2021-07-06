import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { ExamComponent } from './exam/exam.component';
import { ConductTestComponent} from './conduct-test/conduct-test.component';
import { ScoreBoardComponent} from './score-board/score-board.component';
import {AdmincontrolsComponent} from './admincontrols/admincontrols.component';
import { from } from 'rxjs';
import { RegisterComponent } from './register/register.component';


@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CounterComponent,
    FetchDataComponent,
    ExamComponent,
    ConductTestComponent,
    ScoreBoardComponent,
    AdmincontrolsComponent,
    RegisterComponent,
  
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'counter', component: CounterComponent },
      { path: 'fetch-data', component: FetchDataComponent },
      { path: 'exam', component:ExamComponent},
      { path: 'conductTest', component:ConductTestComponent},
      { path: 'scoreBoard', component:ScoreBoardComponent},
      { path: 'admin', component: AdmincontrolsComponent },
      { path: 'register', component: RegisterComponent },
      //{ path: 'login', component: LoginComponent}
    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
