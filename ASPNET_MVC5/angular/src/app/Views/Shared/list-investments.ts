import { Component, Input, Output } from '@angular/core';
import { ApiService } from '../../apiservice.service';
import { Investment } from '../../Models/investment';
import { InvestmentUtilities } from '../../Utilities';

@Component({
  selector: 'app-list-investments',
  templateUrl: './list-investments.html'
})
export class ListInvestmentsComponent {
  errorMessage: string;
  Investments: Investment[] = [];
  private util: InvestmentUtilities;
  _Entity: any;
  @Input()
  set Entity(e: any) {
    this._Entity = e;
    this._Entity.investments.forEach((i, index) => {
      this.apiService.GetInvestment(+i.investmentID).subscribe( (investment) => {
        this.Investments.push(this.util.populateInvestmentFully(investment));
      },  error => this.errorMessage = <any>error);
    });
  }
  get Entity(): any {
    return this._Entity;
  }


  constructor(private apiService: ApiService) {
    this.util = new InvestmentUtilities(this.apiService);
  }
}
