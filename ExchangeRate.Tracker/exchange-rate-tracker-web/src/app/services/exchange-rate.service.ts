import { Injectable } from '@angular/core';
import { ExchangeRate } from '../models/exchange-rate';
import { CurrencyDto, ExchangeRateClient, IExchangeRateClient, IMnbExchangeRate } from '../api/exchangerate-client';
import { BehaviorSubject, Observable, Subscriber } from 'rxjs';
import { Currency } from '../models/currency';

@Injectable({
  providedIn: 'root'
})
export class ExchangeRateService {

  private readonly _exchangeRate$ = new BehaviorSubject<ExchangeRate[]>([]);
  private readonly _currencies$ = new BehaviorSubject<Currency[]>([]);

  private readonly _client: ExchangeRateClient;

  constructor(client: ExchangeRateClient) {
    this._client = client;
  }

  get exchangeRates$(): Observable<ExchangeRate[]> {
    return this._exchangeRate$.asObservable();
  }

  get currencies$(): Observable<Currency[]> {
    return this._currencies$.asObservable();
  }

  fetchExchangeRates(currency: string, from: Date, to: Date) {
    this._client.getByCurrency(currency, from, to)
      .subscribe((data: IMnbExchangeRate[]) => {
        this._exchangeRate$.next(data.map((exchangeRate: IMnbExchangeRate) =>
          new ExchangeRate(undefined, exchangeRate.currency ?? '', exchangeRate.day ?? new Date(), exchangeRate.value ?? 0, undefined))
        )
      });
  }

  fetchCurrencies() {
    this._client.currencies().subscribe((data: CurrencyDto[]) => {
      this._currencies$.next(data.map((value: CurrencyDto) => new Currency(value.name ?? '')));
    });
  }

  updateCurrency(selectedCurrency: any) {
    throw new Error('Method not implemented.');
  }
}
