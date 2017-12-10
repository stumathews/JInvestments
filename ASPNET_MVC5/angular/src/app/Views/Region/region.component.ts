import { Component } from '@angular/core';
import { ApiService } from '../../apiservice.service';
import { Region } from './Region';

@Component({
  selector: 'app-region',
  templateUrl: './region.component.html'
})
export class RegionComponent {
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
