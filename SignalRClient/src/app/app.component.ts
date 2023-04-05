import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { SignalRService } from './services/signal-r.service';
import { ChartConfiguration, ChartType } from 'chart.js';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit{
  title = 'SignalRClient';

  chartLabels: string[] = ['Real time data '];

  constructor(public signalRService: SignalRService, private http: HttpClient) {}

  ngOnInit(){
    this.signalRService.startConnection();
    this.signalRService.addChartDataListener();
    this.startHttpRequest();
  }

  private startHttpRequest = () => {
    this.http.get('https://localhost:2702/api/chart')
      .subscribe(res => console.log('Api response: '+ res));
  }
}
