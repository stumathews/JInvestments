import { Component } from '@angular/core';
import { ApiService } from '../../apiservice.service';
import { Investment } from './investment';

@Component({
  selector: 'app-investment-detail',
  templateUrl: './investment.detail.component.html',
  inputs: ['investment']
})
export class InvestmentDetailComponent {
  id: number;
  Investment: Investment;
  constructor(private apiService: ApiService) { }

  errorMessage: string;
  ngOnInit(): void {
    this.apiService.GetInvestment(this.id)
        .subscribe(investment => this.Investment = investment,
                   error => this.errorMessage = <any>error);
  }
}
