import { Component, OnInit, Input } from '@angular/core';
import { ApiService } from '../../apiservice.service';
import { InvestmentRisk } from '../../Models/InvestmentRisk';
import { ActivatedRoute } from '@angular/router';
import { Location } from '@angular/common';

@Component({
  selector: 'app-risk-details',
  templateUrl: './risk-details.html'
})
export class RiskDetailsComponent implements OnInit {
  Risk: InvestmentRisk;
  constructor(private apiService: ApiService, private route: ActivatedRoute, private location: Location) { }

  errorMessage: string;
  ngOnInit(): void {
    const id = +this.route.snapshot.paramMap .get('id');
    this.apiService.GetRisk(id).subscribe(risk => this.Risk = risk,
                   error => this.errorMessage = <any>error);
  }
}
