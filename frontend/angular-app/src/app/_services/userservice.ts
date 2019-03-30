import { Injectable } from "../../../node_modules/@angular/core";
import { Http, Headers, Response, URLSearchParams, RequestOptions } from '@angular/http';
import {CONFIG} from '../app.config';

@Injectable()
export class UserService {

    private activeUser : string;
    private baseurl : string  = CONFIG.apiURL;

    constructor(private http : Http) { }

    setLoggedInUser(user : string) : void {
        this.activeUser = user;  
        let headers = new Headers();
        headers.append('Content-Type','application/json');
        this.http.post(this.baseurl + "/users/register", JSON.stringify(this.activeUser), { headers: headers})
                 .subscribe(resp => console.log(resp));
    }

    getLoggedInUser() : string {
        return this.activeUser;
    }
}