import { Component, OnInit, Input } from '@angular/core';
import { ApiService } from '../../apiservice.service';
import { InvestmentInfluenceFactor } from '../../Models/InvestmentInfluenceFactor';
import { ActivatedRoute } from '@angular/router';
import { Location } from '@angular/common';

@Component({
  selector: 'app-factor-details',
  templateUrl: './factor-details.html'
})
export class FactorDetailsComponent implements OnInit {
  Factor: InvestmentInfluenceFactor;
  constructor(private apiService: ApiService, private route: ActivatedRoute, private location: Location) { }

  errorMessage: string;
  ngOnInit(): void {
    const id = +this.route.snapshot.paramMap .get('id');
    this.apiService.GetFactor(id).subscribe(factor => this.Factor = factor,
                   error => this.errorMessage = <any>error);
  }
}
