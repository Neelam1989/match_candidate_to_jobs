import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'job-data',
  templateUrl: './jobs.component.html'
})
export class JobsDataComponent {
    
  public jobs : Job[];

  constructor(http: HttpClient) {
    http.get<Job[]>('https://localhost:5001/jobs').subscribe(result => {
      this.jobs = result;
    }, error => console.error(error));
  }
}

interface Job {
  jobId: number;
  name: string;
  company: string;
  skills: string;
}

