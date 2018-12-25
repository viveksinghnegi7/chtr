import { Injectable } from "../../../node_modules/@angular/core";
import { HubConnection, HubConnectionBuilder } from '@aspnet/signalr';
import { HttpClientModule, HttpHeaders, HttpRequest } from '@angular/common/http';
import { Http, Headers, Response, URLSearchParams, RequestOptions } from '@angular/http';
import { MatSnackBar } from "@angular/material";

@Injectable()
export class NotificationService {

    private _hubConnection : HubConnection;
    private baseurl : string  = "http://localhost:57255/";
    private baseApiUrl : string = this.baseurl + "api/";
    private chatHubUrl : string = this.baseurl + "chat";
    constructor(private http : Http, private snackbar : MatSnackBar) {

        let hubConnectionBuilder = new HubConnectionBuilder().withUrl(this.chatHubUrl);
        this._hubConnection = hubConnectionBuilder.build();
    }

    subscribeToGlobalEvents() : void {
        this._hubConnection
        .start()
        .then(() => console.log("Connection established"))
        .catch(err => console.log("Error connecting to SignalR: " + err));
        
        this._hubConnection.on("UserJoined", (userName:string) => {
            this.snackbar.open(userName + " joined the converstation..", "", {
                duration: 5000
            });
        });

        this._hubConnection.on("Say", (message:any) => {
            this.snackbar.open(message.username + ": " + message.content);
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