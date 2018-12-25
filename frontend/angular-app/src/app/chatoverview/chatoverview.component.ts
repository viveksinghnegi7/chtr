import { Component, OnInit } from '@angular/core';
import {UserService} from '../_services/userservice';
import {NotificationService} from '../_services/notificationservice';

@Component({
  selector: 'app-chatoverview',
  templateUrl: './chatoverview.component.html',
  styleUrls: ['./chatoverview.component.sass']
})
export class ChatoverviewComponent implements OnInit {

  constructor(userService : UserService, private notificationService : NotificationService) { }

  ngOnInit() {
      this.notificationService.subscribeToGlobalEvents();
      this.notificationService.registerUser("Tobias");
  }
}
