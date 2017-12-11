import { Component, OnInit, Input } from '@angular/core';
import { ApiService } from '../../apiservice.service';
import { Region } from '../../Models/Region';

@Component({
  selector: 'app-region',
  templateUrl: './region.html'
})
export class RegionComponent  implements OnInit {
  Regions: Region[];
  constructor(private apiService: ApiService) { }

  errorMessage: string;
  ngOnInit(): void {
    console.log('Hello world');
    this.apiService.GetRegions()
        .subscribe(regions => this.Regions = regions,
                   error => this.errorMessage = <any>error);
  }
}
