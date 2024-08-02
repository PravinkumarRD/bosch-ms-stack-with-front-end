import { Component, OnInit } from '@angular/core';
import { RouterLink, RouterLinkActive, Router } from '@angular/router';

@Component({
  selector: 'bosch-nav-bar',
  standalone: true,
  imports: [RouterLink, RouterLinkActive],
  templateUrl: './nav-bar.component.html',
  styleUrl: './nav-bar.component.css'
})
export class NavBarComponent implements OnInit {

  constructor(private _router: Router) {

  }

  token: string | null;
  role: string | null;
  ngOnInit(): void {
    this._router.events.subscribe({
      next: value => {
        this.token = localStorage.getItem('token');
        this.role = localStorage.getItem('role');
      }
    });
    console.log(this.token)
  }

  onLogout(): void {
    this.token = null;
    localStorage.clear();
  }
}
