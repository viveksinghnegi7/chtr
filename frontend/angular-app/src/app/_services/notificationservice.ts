import { Injectable } from "../../../node_modules/@angular/core";
import { HubConnection, HubConnectionBuilder } from '@aspnet/signalr';

@Injectable()
export class NotificationService {

    private _hubConnection : HubConnection;

    /**
     *
     */
    constructor() {
        let hubConnectionBuilder = new HubConnectionBuilder()
                                       .withUrl("http://localhost:57255")                               
        this._hubConnection = hubConnectionBuilder.build();
    }

    notifyNewUser(userName : string){

    }


}