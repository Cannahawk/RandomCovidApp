import { ElementRef } from '@angular/core';
import { TestBed } from '@angular/core/testing';
import { AppResourceService } from '../services/app-resource-service/app-resource.service';
import { ResourceDirective } from './resource.directive';

describe('ResourceDirective', () => {
  it('should create an instance', () => {
    const directive = new ResourceDirective(TestBed.inject(AppResourceService), new ElementRef(null));
    expect(directive).toBeTruthy();
  });
});
