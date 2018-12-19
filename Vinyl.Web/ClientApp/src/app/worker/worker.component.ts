import { Component, OnInit } from '@angular/core';
import { Worker } from './Worker';
import { HttpClient, HttpErrorResponse } from "@angular/common/http";

@Component({
  templateUrl: './worker.component.html'
})
export class WorkerComponent implements OnInit {
    
  workers: Worker[]
  url: string = 'https://localhost:44310/api/worker/get';

  constructor(private http: HttpClient) { }

  ngOnInit(): void {
    this.http.get<Worker[]>(this.url).subscribe(
      workers => this.workers = workers
      );
  }
}
