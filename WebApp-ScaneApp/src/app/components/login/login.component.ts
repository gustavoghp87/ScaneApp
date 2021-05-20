import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ApiauthService } from 'src/app/services/apiauth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.sass']
})
export class LoginComponent implements OnInit {

  public email: string = "";
  public password: string = "";
  
  constructor(private apiauthService: ApiauthService, private router: Router) {
    console.log(this.apiauthService.GetUserData);
    
    if (this.apiauthService.GetUserData) this.GoHome()
  }

  ngOnInit(): void {
  }

  private GoHome() {
    this.router.navigate(['/home'])
  }

  Login() {
    this.apiauthService.Login(this.email, this.password).subscribe(response => {
      console.log(response);
      if (response.success === 1) this.GoHome()
    });
  }

}
