import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';

@Injectable()
export class AuthService {
  private _registerUrl = "https://localhost:44398/api/Users/register";
  private _loginUrl = "https://localhost:44398/api/Users/login";
  private _userurl = "https://localhost:44398/api/Users";
  constructor(private http: HttpClient,private _router:Router) { }

  registerUser(user: any) {
    return this.http.post<any>(this._registerUrl, user);
  }
  loginUser(user: any) {
    return this.http.post<any>(this._loginUrl, user);
  }
  loggedIn()
  {
    return !!localStorage.getItem('token')
  }
  logoutUser(){
    localStorage.removeItem('token');
    this._router.navigate(['/home']);
  }
  getUsers() {
    return this.http.get<any>(this._userurl);
  }
}