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
import { InvestmentInfluenceFactor } from '../../Models/InvestmentInfluenceFactor';
import { InvestmentService } from '../../investment.service';
import { FactorsLink } from '../../Models/Investment';



@Component({
  selector: 'app-select-factors',
  templateUrl: 'select-entities.html',
  })

export class SelectFactorsComponent implements OnInit {
  constructor(private apiService: ApiService,
              private route: ActivatedRoute,
              private location: Location,
              private router: Router,
              private investmentService: InvestmentService) { }
  Type: EntityTypes = EntityTypes.InvestmentInfluenceFactor;
  EntityTypes = EntityTypes;
  Factors: InvestmentInfluenceFactor[];
  error: string;
  Items: CheckModel[];
  ngOnInit(): void {
    this.apiService.GetFactors().subscribe(factors => {
         this.Items = factors.map( (value, index, array) => {
            return <CheckModel> {  id: value.id, name: value.name, description: value.description, checked: false };  });
        },
        error => this.error = <any>error);
  }
  onNext() {
    this.investmentService.SelectedFactors = this.Items.map((value) => {
      if (value.checked === true) {
        return <InvestmentInfluenceFactor> {
            id: value.id,
            name: value.name,
            description: value.description,
            influence: '',
            investments : null};
      }
    });
    console.log('saved.');
    this.router.navigateByUrl('/NewInvestmentWizard/(NewInvestmentWizardOutlet:SelectRisks)');
  }
}

