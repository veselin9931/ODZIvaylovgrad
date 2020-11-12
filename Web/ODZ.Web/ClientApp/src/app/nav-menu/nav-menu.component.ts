import { Component, OnInit } from '@angular/core';
import { AccountService } from '../_services/'

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css']
})

export class NavMenuComponent {
  isExpanded = true;
  isLoggedIn;

  constructor(
    private accountService: AccountService,

  ) { this.isLoggedIn = localStorage.getItem("user"); }

  collapse() {
    this.isExpanded = true;
  }

  LogOut() {
    this.accountService.logout();
    this.isLoggedIn = "";
      

  }
  toggle() {
    this.isExpanded = !this.isExpanded;
  }
}
