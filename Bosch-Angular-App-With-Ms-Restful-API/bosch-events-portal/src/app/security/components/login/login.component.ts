import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';

import { SecurityService } from "../../services/security.service";

import { AuthResponse } from "../../models/auth-response";
import { User } from "../../models/user";
import { Router } from '@angular/router';
import { CommonModule } from '@angular/common';


@Component({
  selector: 'bosch-login',
  standalone: true,
  imports: [CommonModule,FormsModule],
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent {
  constructor(private _securityService: SecurityService, private _router: Router) {

  }
  title: string = "Bosch Authentication Window!";
  user: User = new User();
  response: AuthResponse;
  errorMessage: string="";
  authenticateUser(): void {
    this._securityService.authenticateCredentials(this.user).subscribe({
      next: data => {
        if (data.token) {
          localStorage.setItem("email", data.email);
          localStorage.setItem("role", data.role);
          localStorage.setItem("token", data.token);
          this._router.navigate(['/home']);
        } else {
          this.errorMessage = data.message;
          console.log(data)
          setTimeout(() => {
            this.errorMessage="";
          }, 5000);
        }
      }
    });
  }
}
