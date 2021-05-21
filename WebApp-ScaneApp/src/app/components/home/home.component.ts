import { Component, OnInit } from '@angular/core';
import { ApiauthService } from 'src/app/services/apiauth.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.sass']
})
export class HomeComponent implements OnInit {

  constructor(private apiauthService: ApiauthService) { }

  ngOnInit(): void {
  }

  Logout() {
    this.apiauthService.Logout();
  }
}
