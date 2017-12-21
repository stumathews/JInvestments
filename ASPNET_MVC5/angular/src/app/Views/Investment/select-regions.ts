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
import { Region } from '../../Models/Region';
import { InvestmentService } from '../../investment.service';



@Component({
  selector: 'app-select-regions',
  templateUrl: 'select-entities.html',
  })

export class SelectRegionsComponent extends SelectEntitiesComponent implements OnInit {
  constructor(private apiService: ApiService,
              private route: ActivatedRoute,
              private location: Location,
              private router: Router,
              private investmentService: InvestmentService) {
                  super();
              }


ngOnInit(): void {
    /* Get all regions from db and convert to checkmodels */
    if (this.investmentService.SelectedRegions && this.investmentService.SelectedRegions.length > 0) {
        console.log('Restoring selected regions');
        this.Items = this.investmentService.SelectedRegions;
    } else {
        this.apiService.GetRegions().subscribe(regions => {
            this.Items = this.ConvertRegionsToCheckModels(regions);
            },
            error => this.error = <any>error);
    }
  }

  ConvertRegionsToCheckModels(regions: Region[]) {
    if (regions) {
        return regions.filter((item) => { if (item) { return item; } }).map( (value, index, array) => {
            return  <CheckModel> {
                id: value.id,
                name: value.name,
                description: value.description,
                checked: false
            };
        });
    }
  }
  onNext() {
      /* Convert selected items and convert to regions */
    this.investmentService.SelectedRegions = this.Items.filter((value) => {  if (value.checked) { return value; } });
    console.log('saved regions selection');
    this.router.navigateByUrl('/NewInvestmentWizard/(NewInvestmentWizardOutlet:SummaryOfNewInvestment)');
  }
}

