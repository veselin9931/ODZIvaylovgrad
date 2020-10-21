import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  constructor() { }

  errorMessage: string = "";

    public creds = {
        username: "",
        password: ""
    };

  ngOnInit(): void {
  }

  onLogin(){

  }
}
