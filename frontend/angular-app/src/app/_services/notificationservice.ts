import { Injectable } from "../../../node_modules/@angular/core";
import { HubConnection, HubConnectionBuilder } from '@aspnet/signalr';
import { HttpClientModule, HttpHeaders, HttpRequest } from '@angular/common/http';
import { Http, Headers, Response, URLSearchParams, RequestOptions } from '@angular/http';
import { MatSnackBar } from "@angular/material";
import { Chat } from "../shared/models/chat";
import { UserService } from "./userservice";
import { EventEmitter } from '@angular/core';

@Injectable()
export class NotificationService {

    private _hubConnection : HubConnection;
    private baseurl : string  = "http://localhost:57256/";
    private baseApiUrl : string = this.baseurl + "api/";
    private chatHubUrl : string = this.baseurl + "chat";

    public chatMessageEmitter$: EventEmitter<Chat>;

    constructor(private http : Http, private snackbar : MatSnackBar, private userService : UserService) {
        let hubConnectionBuilder = new HubConnectionBuilder().withUrl(this.chatHubUrl);
        this._hubConnection = hubConnectionBuilder.build();
        this.chatMessageEmitter$ = new EventEmitter();
    }

    subscribe() : void {
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
            let chat = new Chat(message.username, message.content);
            console.log(chat);
            this.chatMessageEmitter$.emit(chat);
        });
    }

    registerUser(userName : string){
        let url = this.baseApiUrl + "users/register";
        
        let headers = new Headers();
        headers.append('Content-Type','application/json');
        
        this.http.post("http://localhost:57256/api/users/register", JSON.stringify(userName), { headers: headers})
                 .subscribe(resp => console.log(resp));
    }

    say(chat : Chat) {
        let url = this.baseApiUrl + "/chat/say";
        let headers = new Headers();
        headers.append('Content-Type','application/json');
        this.http.post("http://localhost:57256/api/chat/say", JSON.stringify(chat), { headers: headers})
        .subscribe(resp => console.log(resp));
    }
}