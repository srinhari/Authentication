import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { OidcSecurityService } from 'angular-auth-oidc-client';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {
  title = 'oauth-client';
  constructor(public oidcSecurityService: OidcSecurityService, public http: HttpClient) {}
  ngOnInit(): void {
    this.oidcSecurityService.checkAuth().subscribe((auth) => {
      console.log('is authenticated', auth)
    });
  }

  

  login() {
    this.oidcSecurityService.authorize();
  }

  getUsers() {
    const token = this.oidcSecurityService.getToken();
    const httpOptions = {
      headers: new HttpHeaders({
        Authorization: 'Bearer ' + token,
      }),
    };
    this.http.get('https://localhost:6001/users', httpOptions)
      .subscribe((data: any) => {
        console.log('api result', data);
      });
  }

  logout() {
    this.oidcSecurityService.logoff();
  }
}
