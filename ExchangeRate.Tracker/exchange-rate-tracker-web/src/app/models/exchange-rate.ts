export class ExchangeRate {
  readonly id: string;
  readonly currency: string;
  readonly tradingDate: Date;
  readonly value: number;
  readonly comment: string;

  constructor(id: string | undefined, currency: string, tradingDate: Date, value: number, comment: string | undefined) {
    this.id = id ?? '';
    this.currency = currency;
    this.tradingDate = tradingDate ?? new Date();
    this.value = value;
    this.comment = comment ?? '';
  }
}
