import { Component } from '@angular/core';
import { ApiService } from '../../apiservice.service';
import { InvestmentRisk } from './InvestmentRisk';

@Component({
  selector: 'app-risk',
  templateUrl: './risk.component.html'
})
export class RiskComponent {
  Risks: InvestmentRisk[];
  constructor(private apiService: ApiService) { }

  errorMessage: string;
  ngOnInit(): void {
    this.apiService.GetRisks()
        .subscribe(risks => this.Risks = risks,
                   error => this.errorMessage = <any>error);
  }
}
