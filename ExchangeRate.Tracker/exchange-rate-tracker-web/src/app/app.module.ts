import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginComponent } from './components/login/login.component';
import { RegisterComponent } from './components/register/register.component';
import { ExchangeRateListComponent } from './components/exchange-rate-list/exchange-rate-list.component';
import { CurrencyListComponent } from './components/currency-list/currency-list.component';
import { ExchangeRateErditComponent } from './components/exchange-rate-erdit/exchange-rate-erdit.component';

import { InjectionToken } from '@angular/core';

export const API_BASE_URL = new InjectionToken<string>('apiBaseUrl');


@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    RegisterComponent,
    ExchangeRateListComponent,
    CurrencyListComponent,
    ExchangeRateErditComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    AppRoutingModule
  ],
  providers: [
    {
      provide: API_BASE_URL,
      useFactory: apiUrlFactory,
      deps: [],
      multi: false
    },
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }

export function apiUrlFactory(): string {
  // Itt állíthatod be az API_BASE_URL-t például környezeti változókból vagy egyéb forrásból
  return 'https://api.example.com'; // Példa URL
}

