import { Component, OnInit, Input, Output, EventEmitter  } from '@angular/core';
import { ApiService } from '../../apiservice.service';
import { InvestmentGroup } from '../../Models/InvestmentGroup';
import { ActivatedRoute } from '@angular/router';
import { Location } from '@angular/common';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import {Router} from '@angular/router';
import { GetRequiredTextValidators, GetRequiredNumberValidators, EntityTypes, SelectEntitiesComponent } from '../../Utilities';
import { CheckModel } from '../../Models/CheckModel';
import { SelectItemsComponent } from './select-items';
import { InvestmentRisk } from '../../Models/InvestmentRisk';
import { InvestmentService } from '../../investment.service';



@Component({
  selector: 'app-associate-risks',
  templateUrl: 'select-entities.html',
  })

export class AssociateRisksComponent extends SelectEntitiesComponent implements OnInit {
  constructor(private apiService: ApiService,
              private route: ActivatedRoute,
              private location: Location,
              private router: Router) {
                  super();
              }
  ngOnInit(): void {
    this.apiService.GetRisks().subscribe(risks => { this.Items = this.ConvertRisksToCheckModels(risks); },
                                         error => this.error = <any>error);
  }

  onNext() {
    const investmentId = +this.route.snapshot.paramMap.get('id');
    const entityIds = this.GetEntityIds();

    this.apiService
    .AssociateEntityWithInvestment(EntityTypes.InvestmentRisk, entityIds, investmentId)
    .subscribe((value) => {  this.router.navigateByUrl('/InvestmentDetails/' + investmentId); },
               error => {});
  }
}

