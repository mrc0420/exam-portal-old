//import { Injectable } from '@angular/core';
//import { HttpClient} from '@angular/common/http';

//@Injectable({
//  providedIn: 'root'
//})
//export class AuthenticationService
//{

//  constructor(private http: HttpClient) { }

//  login(userName: string, password: string)
//  {
//    return this.http.post<any>("", { userName, password }).pipe(map(user =>
//    {
//      // login successful if there's a jwt token in the response
//      if (user && user.token)
//      {
//        // store user details and jwt token in local storage to keep user logged in between page refreshes
//        localStorage.setItem('currentUser', JSON.stringify(user));
//      }

//      return user;
//    }));

//  }
//  logout() {
//    // remove user from local storage to log user out
//    localStorage.removeItem('currentUser');

//}
