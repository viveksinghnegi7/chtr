import { Component, OnInit } from '@angular/core';
import { Router } from '../../../node_modules/@angular/router';
import {UserService} from '../_services/userservice';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  private user : string;

  constructor(private router : Router, private userService : UserService) {
  }

  ngOnInit() {
  }

  onLogin() {
    this.userService.setLoggedInUser(this.user);
    this.router.navigate(['/chatoverview'])
  }
}
