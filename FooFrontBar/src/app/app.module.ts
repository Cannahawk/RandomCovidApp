import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule, HTTP_INTERCEPTORS} from '@angular/common/http';
import { ChartsModule } from 'ng2-charts';
import { MapsModule } from '@syncfusion/ej2-angular-maps';
import { LegendService, MarkerService, MapsTooltipService, DataLabelService, BubbleService, NavigationLineService, SelectionService,
   AnnotationsService, ZoomService} from '@syncfusion/ej2-angular-maps';

import { AppRoutingModule } from './app-routing.module';
import { HomeComponent } from './components/home/home.component';
import { ResourceDirective } from './directives/resource.directive';
import { DefaultHeaderInterceptor } from './interceptor/default-header-interceptor';
import { NavigationComponent } from './components/navigation/navigation.component';
import { AppComponent } from './components/app/app.component';
import { CommonModule } from '@angular/common';
import { DetailsComponent } from './components/details/details.component';
import { LoaderComponent } from './components/loader/loader.component';
import { CountriesLineChartComponent } from './components/countries-line-chart/countries-line-chart.component';
import { MapComponent } from './components/map/map.component';

@NgModule({
  declarations: [
    HomeComponent,
    ResourceDirective,
    NavigationComponent,
    AppComponent,
    DetailsComponent,
    LoaderComponent,
    CountriesLineChartComponent,
    MapComponent,
  ],
  imports: [
    BrowserModule,
    CommonModule,
    HttpClientModule,
    AppRoutingModule,
    ChartsModule,
    MapsModule,
  ],
  providers: [
    {
      provide: HTTP_INTERCEPTORS,
      useClass: DefaultHeaderInterceptor,
      multi: true
    },
    LegendService, MarkerService, MapsTooltipService, DataLabelService, BubbleService, NavigationLineService , SelectionService,
    AnnotationsService, ZoomService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
