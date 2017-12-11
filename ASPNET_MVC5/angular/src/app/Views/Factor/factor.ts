import { Component, OnInit, Input } from '@angular/core';
import { ApiService } from '../../apiservice.service';
import { InvestmentInfluenceFactor } from '../../Models/InvestmentInfluenceFactor';

@Component({
  selector: 'app-factor',
  templateUrl: './factor.html'
})
export class FactorComponent implements OnInit {
  Factors: InvestmentInfluenceFactor[];
  constructor(private apiService: ApiService) { }

  errorMessage: string;
  ngOnInit(): void {
    this.apiService.GetFactors().subscribe(factors => this.Factors = factors,
                   error => this.errorMessage = <any>error);
  }
}
