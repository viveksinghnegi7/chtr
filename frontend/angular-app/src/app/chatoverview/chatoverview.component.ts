import { Component, OnInit } from '@angular/core';
import {UserService} from '../_services/userservice';
import {NotificationService} from '../_services/notificationservice';
import { Chat } from '../shared/models/chat';

@Component({
  selector: 'app-chatoverview',
  templateUrl: './chatoverview.component.html',
  styleUrls: ['./chatoverview.component.sass']
})
export class ChatoverviewComponent implements OnInit {

  constructor(private userService : UserService, private notificationService : NotificationService) { }

  chatMessage : string;

  ngOnInit() {
      this.notificationService.subscribe();
  }

  onSay(){
    let chat = new Chat();
    chat.userName = this.userService.getLoggedInUser();
    chat.content = this.chatMessage;
    this.notificationService.say(chat);
  }
}
