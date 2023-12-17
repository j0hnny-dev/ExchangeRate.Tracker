import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrl: './register.component.css'
})
export class RegisterComponent {
  username: string = '';
  email: string = '';
  password: string = '';

  constructor(private router: Router) { }

  register() {
    // Itt lehetne a regisztráció logikája, például szerverrel történő kommunikáció
    // A jelenlegi példában csak a konzolra írjuk ki az adatokat
    console.log('Felhasználónév:', this.username);
    console.log('Email:', this.email);
    console.log('Jelszó:', this.password);

    // Példa átnavigálás vissza a bejelentkezési oldalra
    this.router.navigate(['/login']); // A '/login' az útvonal a bejelentkezési oldalhoz
  }
}
