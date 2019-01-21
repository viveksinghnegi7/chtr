import { Component, OnInit } from '@angular/core';
import {UserService} from '../_services/userservice';
import {NotificationService} from '../_services/notificationservice';
import { Chat } from '../shared/models/chat';
import { EventEmitter } from '@angular/core';

@Component({
  selector: 'app-chatoverview',
  templateUrl: './chatoverview.component.html',
  styleUrls: ['./chatoverview.component.scss']
})
export class ChatoverviewComponent implements OnInit {
  
  private chatMessage : string;
  private chatMessages : string[] = [];

  constructor(private userService : UserService, private notificationService : NotificationService) { 
  }

  ngOnInit() {
      this.notificationService.subscribe();
      this.notificationService.chatMessageEmitter$.subscribe(chat => {
        console.log(chat);
        this.chatMessages.push(chat.Username + " said: " + chat.content);
      });
  }

  onSay(){
    let user = this.userService.getLoggedInUser();
    let chat = new Chat(user, this.chatMessage);
    this.notificationService.say(chat);
  }

  onSubmitChatMessage() {
    this.onSay();
    this.chatMessage = '';
  }
}
