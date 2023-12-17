import { Component, OnInit } from '@angular/core';
import { ExchangeRateService } from '../../services/exchange-rate.service';
import { ExchangeRate } from '../../models/exchange-rate';

@Component({
  selector: 'app-exchange-rate-list',
  templateUrl: './exchange-rate-list.component.html',
  styleUrls: ['./exchange-rate-list.component.css']
})
export class ExchangeRateListComponent implements OnInit {
  exchangeRates: ExchangeRate[] = [];

  constructor(private exchangeRateService: ExchangeRateService) { }

  ngOnInit() {
    this.getRates();
  }

  getRates() {
    this.exchangeRateService.exchangeRates$.subscribe((data: ExchangeRate[]) => {
      this.exchangeRates = data;
    })
  }
}
