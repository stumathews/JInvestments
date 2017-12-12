import { Component, OnInit, Input } from '@angular/core';
import { ApiService } from '../../apiservice.service';
import { Region } from '../../Models/Region';
import { ActivatedRoute } from '@angular/router';
import { Location } from '@angular/common';

@Component({
  selector: 'app-region-details',
  templateUrl: './region-details.html'
})
export class RegionDetailsComponent implements OnInit {
  Region: Region;
  constructor(private apiService: ApiService, private route: ActivatedRoute, private location: Location) { }

  errorMessage: string;
  ngOnInit(): void {
    const id = +this.route.snapshot.paramMap .get('id');
    this.apiService.GetRegion(id).subscribe(region => this.Region = region,
                   error => this.errorMessage = <any>error);
  }
}
