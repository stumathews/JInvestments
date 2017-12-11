import { Component, OnInit, Input } from '@angular/core';
import { ApiService } from '../../apiservice.service';
import { Investment } from '../../Models/investment';
import { ActivatedRoute } from '@angular/router';
import { Location } from '@angular/common';

@Component({
  selector: 'app-investment-detail',
  templateUrl: './investment.detail.html',
  })

export class InvestmentDetailComponent implements OnInit {
  investment: Investment;
  constructor(private apiService: ApiService, private route: ActivatedRoute, private location: Location) { }

  errorMessage: string;
  ngOnInit(): void {
    const id = +this.route.snapshot.paramMap .get('id');
    this.apiService.GetInvestment(id)
        .subscribe(investment => this.investment = investment,
                   error => this.errorMessage = <any>error);
  }
}
