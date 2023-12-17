import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Currency } from '../../models/currency';
import { ExchangeRateService } from '../../services/exchange-rate.service';

@Component({
  selector: 'app-currency-list',
  templateUrl: './currency-list.component.html',
  styleUrls: ['./currency-list.component.css']
})
export class CurrencyListComponent implements OnInit {
  currencies: Currency[] = [];

  constructor(private exchangeRateService: ExchangeRateService, private router: Router) { }

  ngOnInit() {
    this.exchangeRateService.currencies$.subscribe((data: Currency[]) => {
      this.currencies = data;
    });
  }

  navigateToExchangeRateList() {
    this.router.navigate(['/exchange-rate-list']);
  }
}
