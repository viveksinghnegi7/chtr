import { Injectable } from "../../../node_modules/@angular/core";
import { HubConnection, HubConnectionBuilder } from '@aspnet/signalr';
import { HttpClientModule, HttpHeaders, HttpRequest } from '@angular/common/http';
import { Http, Headers, Response, URLSearchParams, RequestOptions } from '@angular/http';

@Injectable()
export class NotificationService {

    private _hubConnection : HubConnection;
    private baseurl : string  = "http://localhost:57255/";
    private baseApiUrl : string = this.baseurl + "api/";
    public chatHubUrl : string = this.baseurl + "chat";

    constructor(private http : Http) {
        let hubConnectionBuilder = new HubConnectionBuilder().withUrl(this.chatHubUrl);
        this._hubConnection = hubConnectionBuilder.build();
    }

    subscribeToGlobalEvents() : void {
        this._hubConnection
        .start()
        .then(() => console.log("Connection established"))
        .catch(err => console.log("Error connecting to SignalR: " + err));
        
        this._hubConnection.on("UserJoined", (userName:string) => {
            console.log("SignalR event happend");
            console.log("userName: " + userName);
        });
    }

    registerUser(userName : string){
        let url = this.baseApiUrl + "users/register";
        
        let headers = new Headers();
        headers.append('Content-Type','application/json');
        
   
        this.http.post("http://localhost:57255/api/users/register", JSON.stringify(userName), { headers: headers})
                 .subscribe(resp => console.log(resp));
    }
}