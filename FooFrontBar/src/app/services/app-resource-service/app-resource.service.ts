import { Injectable } from '@angular/core';
import langEN from './languages/lang-en.json';
import langDE from './languages/lang-de.json';

@Injectable({
  providedIn: 'root'
})
export class AppResourceService {

  private resources: {[key: string]: string};

  constructor() {
    if (sessionStorage.getItem('language') == null) {
      const defaultLang = navigator.language;
      this.setLanguage(defaultLang ? defaultLang.substring(0, 2) : 'en');
    } else {
      this.setLanguage(sessionStorage.getItem('language'));
    }
  }

  get(key: string): string {
    if (this.resources.hasOwnProperty(key)) {
      return this.resources[key];
    } else {
      return key;
    }
  }

  setLanguage(language: string): void {
    switch (language) {
      case 'de':
        this.resources = langDE;
        sessionStorage.setItem('language', 'de');
        break;
      case 'en':
      default:
        this.resources = langEN;
        sessionStorage.setItem('language', 'en');
        break;
    }
  }
}
