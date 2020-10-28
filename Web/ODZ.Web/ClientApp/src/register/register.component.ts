import { HttpErrorResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { DataService } from '../app/shared/data.service';
import { UserRegister } from '../app/shared/user-register';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent {

  constructor(private dataService: DataService) { }

  public userRegister: UserRegister = new UserRegister();
  public errorMessage: string = null;

  public register() : void{
    console.log(JSON.stringify(this.userRegister));
    this.dataService.register(this.userRegister).subscribe(
      () => { },
      (error: HttpErrorResponse) => this.errorMessage = error.error || 'Invalid registration.');
  }

}
 