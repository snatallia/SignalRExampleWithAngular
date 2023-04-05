import { Injectable } from '@angular/core';
import * as signalR from '@aspnet/signalr';
import { Chart } from '../interfaces/chart.model';

@Injectable({
  providedIn: 'root'
})
export class SignalRService {

  public data: Chart[];
  private hubConnection: signalR.HubConnection;

  public startConnection = () => {
    this.hubConnection = new signalR.HubConnectionBuilder()
                .withUrl('https://localhost:2702/chart')
                .build();

    this.hubConnection
      .start()
      .then(() => console.log('HubConnection started.'))
      .catch(err => console.log('HubConnection starting error.'));

  }

  public addChartDataListener = () => {
    this.hubConnection.on('getchartdata', (resdata) => {
      this.data = resdata;
      console.log('Data from server: ' + resdata)
    })
  }
}
