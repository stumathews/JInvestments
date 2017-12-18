import { Component, OnInit, Input } from '@angular/core';
import { ApiService } from '../../apiservice.service';
import { Investment } from '../../Models/investment';
import { ActivatedRoute } from '@angular/router';
import { Location } from '@angular/common';
import { EntityTypes, DetailComponentBase } from '../../Utilities';

@Component({
  selector: 'app-investment-detail',
  templateUrl: './investment.detail.html',
  })

export class InvestmentDetailComponent extends DetailComponentBase implements OnInit {
  Entity: Investment;
  constructor(protected apiService: ApiService, private route: ActivatedRoute, private location: Location) {
    super(apiService);
    this.MyType = EntityTypes.Investment;
   }

  errorMessage: string;
  ngOnInit(): void {
    const id = +this.route.snapshot.paramMap .get('id');
    this.apiService.GetInvestment(id)
        .subscribe(investment => this.Entity = investment,
                   error => this.errorMessage = <any>error);
  }
}
