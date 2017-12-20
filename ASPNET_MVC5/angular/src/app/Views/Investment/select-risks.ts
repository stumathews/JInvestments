import { Component, OnInit, Input, Output, EventEmitter  } from '@angular/core';
import { ApiService } from '../../apiservice.service';
import { InvestmentGroup } from '../../Models/InvestmentGroup';
import { ActivatedRoute } from '@angular/router';
import { Location } from '@angular/common';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import {Router} from '@angular/router';
import { GetRequiredTextValidators, GetRequiredNumberValidators, EntityTypes } from '../../Utilities';
import { CheckModel } from '../../Models/CheckModel';
import { SelectItemsComponent } from './select-items';
import { InvestmentRisk } from '../../Models/InvestmentRisk';
import { InvestmentService } from '../../investment.service';



@Component({
  selector: 'app-select-risks',
  templateUrl: 'select-entities.html',
  })

export class SelectRisksComponent implements OnInit {
  constructor(private apiService: ApiService,
              private route: ActivatedRoute,
              private location: Location,
              private router: Router,
              private investmentService: InvestmentService) { }
  Type: EntityTypes = EntityTypes.InvestmentRisk;
  EntityTypes = EntityTypes;
  Risks: InvestmentRisk[];
  error: string;
  Items: CheckModel[];
  ngOnInit(): void {
    this.apiService.GetRisks().subscribe(risks => {
         this.Items = risks.map( (value, index, array) => {
            return  <CheckModel> {  id: value.id, name: value.name, description: value.description, checked: false };  });
        },
        error => this.error = <any>error);
  }
  onNext() {
    this.investmentService.SelectedRisks = this.Items.map((value) => {
      if (value.checked === true) {
        return <InvestmentRisk> {  id: value.id,
             name: value.name, description: value.description, type: 0, influence: '', investments: null };
      }
    });
    console.log('saved risks selection');
    this.router.navigateByUrl('/NewInvestmentWizard/(NewInvestmentWizardOutlet:SelectGroups)');
  }
}

