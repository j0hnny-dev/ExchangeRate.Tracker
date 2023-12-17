import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent {
  email: string = '';
  password: string = '';

  constructor(private router: Router) { }

  login() {
    // Itt lehetne az autentikáció logikája, például szerverrel történő kommunikáció
    // A jelenlegi példában csak a konzolra írjuk ki az adatokat
    console.log('Email:', this.email);
    console.log('Password:', this.password);

    // Példa átnavigálásra a regisztráció oldalra
    this.router.navigate(['/register']); // A '/register' az útvonal a regisztrációs oldalhoz
  }
}
