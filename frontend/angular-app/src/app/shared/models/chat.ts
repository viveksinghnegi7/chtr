export class Chat {
   
    private Username:string;
    private content:string;

    constructor(userName : string, content : string) {
       this.Username = userName;
       this.content = content;
    }
}