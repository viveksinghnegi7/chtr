import { Injectable } from "../../../node_modules/@angular/core";

@Injectable()
export class UserService {

    private activeUser : string;

    setLoggedInUser(user : string) : void {
        this.activeUser = user;
    }

    getLoggedInUser() : string {
        return this.activeUser;
    }
}