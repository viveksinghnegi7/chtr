import { Component, OnInit } from '@angular/core';
import {UserService} from '../_services/userservice';

@Component({
  selector: 'app-chatoverview',
  templateUrl: './chatoverview.component.html',
  styleUrls: ['./chatoverview.component.sass']
})
export class ChatoverviewComponent implements OnInit {

  constructor(userService : UserService) { }

  ngOnInit() {
      
  }
}
