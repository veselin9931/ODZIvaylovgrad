import { HttpErrorResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { DataService } from '../shared/data.service';
import { UserLogin } from '../shared/user-login';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent{

  constructor(private dataService: DataService) { }

  public userLogin: UserLogin = new UserLogin();
    public errorMessage: string = null;

    public login(): void {
        this.dataService.login(this.userLogin).subscribe(
            () => { },
            (error: HttpErrorResponse) => this.errorMessage = error.error || 'Invalid login.');
    }

  onLogin(){

  }
}
