import { Component, OnInit, Input } from '@angular/core';
import { Investment } from './Models/investment';
import { InvestmentGroup } from './Models/InvestmentGroup';
import { InvestmentInfluenceFactor } from './Models/InvestmentInfluenceFactor';
import { InvestmentRisk } from './Models/InvestmentRisk';
import { Region } from './Models/Region';
import { ApiService } from './apiservice.service';
import { FormGroup, FormControl, Validators } from '@angular/forms';

export abstract class DetailComponentBase implements OnInit  {
    Entity: Investment | InvestmentGroup | InvestmentInfluenceFactor | InvestmentRisk | Region;
    MyType: EntityTypes = EntityTypes.InvestmentRisk;
    errorMessage: string;
    constructor(protected apiService: ApiService) { }

    ngOnInit() { }

    public saveEditable(element, id: number) {
            const property = element.name;
            const newVal = this.Entity[property];
            console.log('name=' + element.name);
            console.log('http.service.UpdateEntity(' + id + ',' + property + ',' + this.Entity[property] + ')');

            this.apiService.UpdateEntity(this.MyType, +id, property, newVal)
                           .subscribe(code =>  console.log('back from patch'),
                                      error => this.errorMessage = <any>error);
          }
}

export function GetRequiredTextValidators() {
    return Validators.compose( [
      Validators.required,
      Validators.pattern('[\\w\\-\\s\\|$|£/]+')]);
   }

 export function GetRequiredNumberValidators() {
    return Validators.compose( [
      Validators.required,
      Validators.pattern('\\d+')]);
   }

export enum EntityTypes {
    Investment = 1,
    InvestmentInfluenceFactor,
    InvestmentRisk,
    InvestmentGroup,
    Region,
}

@Component({})

export class InvestmentUtilities {
    constructor(private apiService: ApiService) { }
    errorMessage: string;
    populateInvestmentFully(investment: Investment) {
        investment.factors.forEach((factor, findex) => {
        this.apiService.GetFactor(factor.investmentInfluenceFactorID).subscribe( result => {
            factor.investmentInfluenceFactor = result;
        }, error => this.errorMessage = <any>error);
        });
        investment.risks.forEach((risk, riskIndex) => {
        this.apiService.GetRisk(risk.investmentRiskID).subscribe( result => {
            risk.investmentRisk = result;
        }, error => this.errorMessage = <any>error);
        });
        investment.regions.forEach((region, regionIndex) => {
        this.apiService.GetRegion(region.regionID).subscribe( result => {
            region.region = result;
        }, error => this.errorMessage = <any>error);
        });
        investment.groups.forEach((group, gindex) => {
        this.apiService.GetGroup(group.investmentGroupID).subscribe( result => {
            group.investmentGroup = result;
        }, error => this.errorMessage = <any>error);
        });
        return investment;
    }
  }
