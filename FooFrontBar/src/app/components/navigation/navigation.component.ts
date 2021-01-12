import { Component } from '@angular/core';
import { AppResourceService } from 'src/app/services/app-resource-service/app-resource.service';

@Component({
  selector: 'app-navigation',
  templateUrl: './navigation.component.html',
  styleUrls: ['./navigation.component.less']
})
export class NavigationComponent {

  constructor(private appResourceService: AppResourceService) { }

  setLanguageGerman(): void {
    this.appResourceService.setLanguage('de');
    location.href = location.href;
  }

  setLanguageEnglish(): void {
    this.appResourceService.setLanguage('en');
    location.href = location.href;
  }

}
