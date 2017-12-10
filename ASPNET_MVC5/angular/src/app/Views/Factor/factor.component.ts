import { Component } from '@angular/core';
import { ApiService } from '../../apiservice.service';
import { InvestmentInfluenceFactor } from './InvestmentInfluenceFactor';

@Component({
  selector: 'app-factor',
  templateUrl: './factor.component.html'
})
export class FactorComponent {
  Factors: InvestmentInfluenceFactor[];
  constructor(private apiService: ApiService) { }

  errorMessage: string;
  ngOnInit(): void {
    this.apiService.GetFactors()
        .subscribe(factors => this.Factors = factors,
                   error => this.errorMessage = <any>error);
  }
}
