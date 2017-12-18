import { Component, OnInit, Input } from '@angular/core';
import { Investment } from './Models/investment';
import { ApiService } from './apiservice.service';
import { FormGroup, FormControl, Validators } from '@angular/forms';



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
