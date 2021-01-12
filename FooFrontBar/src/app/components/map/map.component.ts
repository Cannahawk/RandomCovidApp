import { Component, OnInit, ViewEncapsulation, OnDestroy } from '@angular/core';
import { Maps, Legend } from '@syncfusion/ej2-angular-maps';
import { Subscription } from 'rxjs';
import { Country } from 'src/app/models/country';
import { CountryService } from 'src/app/services/http-services/country.service';
import { worldMap } from './world-map';

Maps.Inject(Legend);
@Component({
  selector: 'app-map',
  templateUrl: './map.component.html',
  styleUrls: ['./map.component.less'],
  encapsulation: ViewEncapsulation.None
})
export class MapComponent implements OnInit, OnDestroy {

  shapeData: object;
  shapePropertyPath: string;
  shapeDataPath: string;
  dataSource: object[];
  shapeSettings: object;
  legendSettings: object;
  subscriptions: Subscription[] = [];
  countries: Country[];
  constructor(private countryService: CountryService) { }

  ngOnInit(): void {
    this.getCountries();
  }

  private getCountries(): void {
    this.subscriptions.push(
      this.countryService.GetAll().subscribe(countries => {
        this.countries = countries;
        this.setupMap();
      })
    );
  }

  private setupMap(): void {
    this.shapeData = worldMap;
    this.shapePropertyPath = 'name';
    this.shapeDataPath = 'Country';
    this.dataSource = this.countries.map(x => {
      return {
        Country: x.name,
        caseRates: this.getCaseRate(x.total)
      };
    });
    this.legendSettings = {
      visible: true
    };
    this.shapeSettings = {
      colorValuePath: 'caseRates',
      colorMapping: [
        {
          value: '< 1000', color: '#00FF00'
        },
        {
          value: '1.000-10.000', color: '#668866'
        },
        {
          value: '10.000-100.000', color: '#00dddd'
        },
        {
          value: '100.000-500.000', color: '#66FFFF'
        },
        {
          value: '500.000 - 1.000.000', color: '#AA6666'
        },
        {
          value: '1.000.000 - 10.000.000', color: '#000000'
        },
        {
          value: '> 10.000.000', color: '#FF0000'
        },
      ]
    };
  }

  private getCaseRate(total: number): string {
    if (total < 1001) {
      return '< 1000';
    } else if (total < 10001) {
      return '1.000-10.000';
    } else if (total < 100001) {
      return '10.000-100.000';
    } else if (total < 500001) {
      return '100.000-500.000';
    } else if (total < 1000001) {
      return '1.000.000 - 10.000.000';
    } else {
      return '> 10.000.000';
    }
  }

  ngOnDestroy(): void {
    this.subscriptions.forEach(subscription => {
      subscription.unsubscribe();
    });
  }
}
