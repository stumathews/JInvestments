import { Component, OnInit, Input } from '@angular/core';
import { ApiService } from '../../apiservice.service';
import { Investment } from '../../Models/investment';
import { InvestmentDetailComponent } from './investment.detail';

@Component({
  selector: 'app-investment',
  templateUrl: './investment.html'
})
export class InvestmentComponent implements OnInit {
  title = 'Home';
  Investments: Investment[];
  constructor(private apiService: ApiService) { }

  errorMessage: string;
  ngOnInit(): void {
    console.log('Hello world');
    this.apiService.GetInvestments()
        .subscribe(investments => this.Investments = investments,
                   error => this.errorMessage = <any>error);
  }
}
