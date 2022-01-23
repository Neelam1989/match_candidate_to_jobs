import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component';
import { JobsDataComponent } from './Jobs/jobs.component';
import { CandidatesDataComponent } from './Candidates/candidates.component';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    JobsDataComponent,
    CandidatesDataComponent,
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: JobsDataComponent, pathMatch: 'full' },
      { path: 'candidates', component: CandidatesDataComponent },
    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
