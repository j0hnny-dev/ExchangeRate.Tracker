import { Component, Input } from '@angular/core';
import { ExchangeRateService } from '../../services/exchange-rate.service';

@Component({
  selector: 'app-exchange-rate-erdit',
  templateUrl: './exchange-rate-erdit.component.html',
  styleUrl: './exchange-rate-erdit.component.css'
})
export class ExchangeRateErditComponent {
  @Input() selectedCurrency: any;

  constructor(private exchangeRateService: ExchangeRateService) { }

  saveChanges() {
    // Implementáld a módosítások mentését az ExchangeRateService segítségével
    this.exchangeRateService.updateCurrency(this.selectedCurrency); // Példaként feltételezzük, hogy van egy 'updateCurrency' metódus a szolgáltatásban
    // Frissítsd az adatokat az új adatokkal, vagy hívj egy frissítő metódust a listának
    // pl.: this.exchangeRateService.refreshData();
  }
}
