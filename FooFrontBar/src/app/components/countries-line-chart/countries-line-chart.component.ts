import { Component, Input } from '@angular/core';
import { ChartDataSets } from 'chart.js';
import { Color, Label } from 'ng2-charts';

@Component({
  selector: 'app-countries-line-chart',
  templateUrl: './countries-line-chart.component.html',
  styleUrls: ['./countries-line-chart.component.less']
})
export class CountriesLineChartComponent {

  @Input() lineChartData: ChartDataSets[] = [];
  @Input() lineChartLabels: Label[] = [];
  @Input() title = '';

  lineChartOptions = {
    responsive: true,
    title: this.title,
  };
  lineChartColors: Color[] = [
    {
      borderColor: 'black',
      backgroundColor: 'rgba(255,255,0,0.28)',
    },
  ];
  lineChartLegend = true;
  lineChartPlugins = [];
  lineChartType = 'line';
}
