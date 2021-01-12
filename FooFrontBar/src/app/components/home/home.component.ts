import { Component, OnInit } from '@angular/core';
import { Status } from 'src/app/models/status';
import { StatusService } from 'src/app/services/http-services/status.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.less']
})
export class HomeComponent implements OnInit {

  confirmed: Status;
  death: Status;
  recovered: Status;

  constructor(private statusService: StatusService) { }

  ngOnInit(): void {
    this.GetStatus();
  }

  GetStatus(): void {
    this.statusService.GetAll().subscribe(status => {
      this.confirmed = status.find(x => x.isConfirmed);
      this.death = status.find(x => x.isDeath);
      this.recovered = status.find(x => x.isRecovered);
    });
  }

}
