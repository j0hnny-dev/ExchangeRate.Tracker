import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ExchangeRateErditComponent } from './exchange-rate-erdit.component';

describe('ExchangeRateErditComponent', () => {
  let component: ExchangeRateErditComponent;
  let fixture: ComponentFixture<ExchangeRateErditComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ExchangeRateErditComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(ExchangeRateErditComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
