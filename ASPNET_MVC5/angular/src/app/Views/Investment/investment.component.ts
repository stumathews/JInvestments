import { Component } from '@angular/core';
import { ApiService } from '../../apiservice.service';
import { Investment } from './investment';
import { InvestmentDetailComponent } from './investment.detail.component';

@Component({
  selector: 'app-investment',
  templateUrl: './investment.component.html'
})
export class InvestmentComponent {
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
