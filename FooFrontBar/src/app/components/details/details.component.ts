import { Component, OnDestroy, OnInit } from '@angular/core';
import { Subscription } from 'rxjs';
import { Country } from 'src/app/models/country';
import { Status } from 'src/app/models/status';
import { CountryService } from 'src/app/services/http-services/country.service';
import { StatusService } from 'src/app/services/http-services/status.service';
import { ChartDataSets } from 'chart.js';
import { Label } from 'ng2-charts';
import { AppResourceService } from 'src/app/services/app-resource-service/app-resource.service';
@Component({
  selector: 'app-details',
  templateUrl: './details.component.html',
  styleUrls: ['./details.component.less']
})
export class DetailsComponent implements OnInit, OnDestroy {

  countries: Country[];
  chartDataDeath: ChartDataSets[] = [];
  chartDataRecovered: ChartDataSets[] = [];
  chartDataActive: ChartDataSets[] = [];
  chartDataTotal: ChartDataSets[] = [];
  chartLabels: Label[] = [];
  stati: Status[];
  test = false;
  titleDeath: string;
  titleRecover: string;
  titleTotal: string;
  titleActive: string;
  private subscriptions: Subscription[] = [];

  constructor(
    private countryService: CountryService,
    private statusService: StatusService,
    private appResourceService: AppResourceService) { }

  ngOnInit(): void {
    this.getTranslations();
    this.getCountries();
    this.getStati();
  }

  getTranslations(): void {
    this.titleDeath = this.appResourceService.get('Chart.Death');
    this.titleRecover = this.appResourceService.get('Chart.Recover');
    this.titleActive = this.appResourceService.get('Chart.Active');
    this.titleTotal = this.appResourceService.get('Chart.Total');
  }

  getCountries(): void {
    this.subscriptions.push(
      this.countryService.GetAll().subscribe(countries => {
        this.countries = countries;
      })
    );
  }

  getStati(): void {
    this.subscriptions.push(
      this.statusService.GetAll().subscribe(stati => {
        this.stati = stati;
      })
    );
  }

  updateLineChart(country: Country, event: any): void {
    if (event.target.checked) {
      this.addCountry(country.guid);
    } else {
      this.removeCountry(country);
    }
  }

  addCountry(guid: string): void {
    this.subscriptions.push(
      this.countryService.GetByGuidComplete(guid).subscribe((country) => {
        this.toChartData(country);
        if (this.chartLabels.length === 0) {
          country.history.filter(x => x.isTotal).forEach(x => {
            this.chartLabels.push(x.date.toString());
          });
        }
      })
    );
  }

  removeCountry(country: Country): void {
    this.chartDataDeath = this.chartDataDeath.filter(x => x.label !== country.name);
    this.chartDataActive = this.chartDataActive.filter(x => x.label !== country.name);
    this.chartDataTotal = this.chartDataTotal.filter(x => x.label !== country.name);
    this.chartDataRecovered = this.chartDataRecovered.filter(x => x.label !== country.name);
    this.chartLabels = this.chartLabels.filter( x => x !== country.name);
  }

  toChartData(country: Country): void {
    const death: number[] = [];
    const active: number[] = [];
    const recovered: number[] = [];
    const total: number[] = [];

    country.history
      .filter(x => x.isDeath)
      .map((x) => death.push(x.amount));

    country.history
      .filter(x => x.isRecovered)
      .map((x) => recovered.push(x.amount));

    country.history
      .filter(x => x.isTotal)
      .map((x) => total.push(x.amount));

    total.map((x, index) => {
      active.push(x - recovered[index] - death[index]);
    });

    this.chartDataActive.push({data: active, label: country.name});
    this.chartDataDeath.push({data: death, label: country.name});
    this.chartDataRecovered.push({data: recovered, label: country.name});
    this.chartDataTotal.push({data: total, label: country.name});
  }

  ngOnDestroy(): void {
    this.subscriptions.forEach(subscription => {
      subscription.unsubscribe();
    });
  }
}
