import { Component, OnInit, Input } from '@angular/core';
import { ApiService } from '../../apiservice.service';
import { InvestmentRisk } from '../../Models/InvestmentRisk';

@Component({
  selector: 'app-risk',
  templateUrl: './risk.html'
})
export class RiskComponent implements OnInit {
  Risks: InvestmentRisk[];
  constructor(private apiService: ApiService) { }

  errorMessage: string;
  ngOnInit(): void {
    this.apiService.GetRisks()
        .subscribe(risks => this.Risks = risks,
                   error => this.errorMessage = <any>error);
  }
}
