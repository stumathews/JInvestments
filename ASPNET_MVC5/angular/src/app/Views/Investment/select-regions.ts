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
import { Region } from '../../Models/Region';
import { InvestmentService } from '../../investment.service';



@Component({
  selector: 'app-select-regions',
  templateUrl: 'select-entities.html',
  })

export class SelectRegionsComponent implements OnInit {
  constructor(private apiService: ApiService,
              private route: ActivatedRoute,
              private location: Location,
              private router: Router,
              private investmentService: InvestmentService) { }
  Type: EntityTypes = EntityTypes.Region;
  EntityTypes = EntityTypes;
  Regions: Region[];
  error: string;
  Items: CheckModel[];
  ngOnInit(): void {
    this.apiService.GetRegions().subscribe(regions => {
         this.Items = regions.map( (value, index, array) => {
            return  <CheckModel> {  id: value.id, name: value.name, description: value.description, checked: false };  });
        },
        error => this.error = <any>error);
  }
  onNext() {
    this.investmentService.SelectedRegions = this.Items.map((value) => {
      if (value.checked === true) {
        return <Region> {  id: value.id,
             name: value.name, description: value.description, investments: null };
      }
    });
    console.log('saved regions selection');
    this.router.navigateByUrl('/NewInvestmentWizard/(NewInvestmentWizardOutlet:SummaryOfNewInvestment)');
  }
}

