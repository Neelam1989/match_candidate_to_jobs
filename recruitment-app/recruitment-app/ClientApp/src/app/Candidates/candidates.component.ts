import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ActivatedRoute } from '@angular/router';
import { Output, EventEmitter } from '@angular/core';

@Component({
  selector: 'candidate-data',
  templateUrl: './candidates.component.html'
})
export class CandidatesDataComponent  {
  
  public candidates: Candidates[];

  constructor(http: HttpClient, private route: ActivatedRoute) {
    this.route.queryParams
      .subscribe(params => {
        var jobId = params.jobId;
        http.get<Candidates[]>('https://localhost:5001/candidatessearch?jobId=' + jobId).subscribe(result => {
          this.candidates = result;
        }, error => console.error(error));
      });
    
  }
}

interface Candidates {
  candidateId: number;
  name: string;
  skillTags: string;
}

