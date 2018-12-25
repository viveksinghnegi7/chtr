import { Injectable } from "../../../node_modules/@angular/core";
import { Http, Headers, Response, URLSearchParams, RequestOptions } from '@angular/http';

@Injectable()
export class UserService {

    private activeUser : string;
    private baseurl : string  = "http://localhost:57255/api";

    constructor(private http : Http) {
        
    }

    setLoggedInUser(user : string) : void {
        this.activeUser = user;
        let url = this.baseurl + "users/register";
        
        let headers = new Headers();
        headers.append('Content-Type','application/json');
        
        this.http.post("http://localhost:57255/api/users/register", JSON.stringify(this.activeUser), { headers: headers})
                 .subscribe(resp => console.log(resp));
    }

    getLoggedInUser() : string {
        return this.activeUser;
    }
}