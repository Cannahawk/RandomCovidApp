import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CountriesLineChartComponent } from './countries-line-chart.component';

describe('CountriesLineChartComponent', () => {
  let component: CountriesLineChartComponent;
  let fixture: ComponentFixture<CountriesLineChartComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CountriesLineChartComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CountriesLineChartComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
