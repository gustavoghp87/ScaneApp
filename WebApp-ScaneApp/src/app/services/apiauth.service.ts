import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { backendUrl } from 'src/environments/environment';
import { Response } from '../models/response';
import { User } from '../models/user';
import { GetHttpHeader } from "./GetHttpHeader";

@Injectable({
  providedIn: 'root'
})
export class ApiauthService {

  private _url: string = backendUrl + "/user/login";
  private userSubject: BehaviorSubject<User|null>;

  constructor(private _http: HttpClient) {
    let toParse = localStorage.getItem('user') || "";
    if (!toParse) this.userSubject = new BehaviorSubject<User|null>(null);
    this.userSubject = new BehaviorSubject<User|null>(JSON.parse(toParse));
  }

  public get GetUserData(): User | null {
    return this.userSubject.value;
  }

  Login(email: string, password: string): Observable<Response> {
    return this._http.post<Response>(this._url, {email, password}, GetHttpHeader.GetHttpHeader())
      .pipe(
        map(response => {
          if (response.success === 1) {
            const user: User = response.data;
            localStorage.setItem('user', JSON.stringify(user));
            this.userSubject.next(user);
          }
          return response;
        })
      );
  }

  Logout() {
    localStorage.removeItem('user');
    this.userSubject.next(null);
  }
}
