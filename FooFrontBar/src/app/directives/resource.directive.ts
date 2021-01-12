import { Directive, Input, OnInit, ElementRef } from '@angular/core';
import { AppResourceService } from '../services/app-resource-service/app-resource.service';

@Directive({
  selector: '[resource]'
})
export class ResourceDirective implements OnInit {

  @Input('resource') resource: string;
  constructor(
    private appResourceService: AppResourceService,
    private element: ElementRef) {
  }

  ngOnInit(): void {
    this.element.nativeElement.innerHTML = this.appResourceService.get(this.resource);
  }
}
