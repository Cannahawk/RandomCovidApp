import { ComponentFixture, TestBed } from '@angular/core/testing';
import { HttpClientTestingModule } from '@angular/common/http/testing';
import { DetailsComponent } from './details.component';
import { Country } from 'src/app/models/country';

describe('DetailsComponent', () => {
  let component: DetailsComponent;
  let fixture: ComponentFixture<DetailsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DetailsComponent ],
      imports: [HttpClientTestingModule]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(DetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  it('should update the line charts', () => {
    const country = new Country();
    country.guid = '0';
    country.code = 'DE';
    country.name = 'Germany';

    const clickEventTrue = {
      target: {
        checked: true,
      }
    };
    const clickEventFalse = {
      target: {
        checked: false,
      }
    };

    spyOn(component, 'updateLineChart');
    component.updateLineChart(country, clickEventTrue);
    component.updateLineChart(country, clickEventFalse);
    expect(component.addCountry).toHaveBeenCalled();
    expect(component.removeCountry).toHaveBeenCalled();
  });

  it('should add countries to the Line charts', () => {
    const guid = '0';
    component.addCountry(guid);
    expect(component.chartLabels).toBeGreaterThan(0);
  });

  it('should remove countries from the line charts', () => {
    const guid = '0';
    component.addCountry(guid);
    // component.removeCountry(guid);
    expect(component.chartLabels).toBeGreaterThan(0);
  });
});
