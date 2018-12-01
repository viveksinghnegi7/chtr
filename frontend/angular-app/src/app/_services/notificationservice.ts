import { Injectable } from "../../../node_modules/@angular/core";
import { HubConnection, HubConnectionBuilder, HttpClient } from '@aspnet/signalr';
import { HttpClientModule, HttpHeaders, HttpRequest } from '@angular/common/http';
import { Http, Headers, Response, URLSearchParams, RequestOptions } from '@angular/http';


@Injectable()
export class NotificationService {

    private _hubConnection : HubConnection;
    private baseurl : string  = "http://localhost:57225/";
    private baseApiUrl : string = this.baseurl + "api/";

    constructor(private http : Http) {
        let hubConnectionBuilder = new HubConnectionBuilder().withUrl("http://localhost:57255")                               
        this._hubConnection = hubConnectionBuilder.build();
    }

    registerUser(userName : string){
        let url = this.baseApiUrl + "users/register";
        
        let headers = new Headers();
        headers.append('Content-Type','application/json');
        
   
        this.http.post("http://localhost:57255/api/users/register", JSON.stringify(userName), { headers: headers})
                 .subscribe(resp => console.log(resp));
    }
}