import { BrowserModule } from '@angular/platform-browser';
import { NgModule, OnInit } from '@angular/core';
import { Injectable } from '@angular/core';
import { Investment } from './Models/investment';
import { InvestmentInfluenceFactor } from './Models/InvestmentInfluenceFactor';
import { InvestmentRisk } from './Models/InvestmentRisk';
import { InvestmentGroup } from './Models/InvestmentGroup';
import { Region } from './Models/Region';
import { InvestmentComponent } from './Views/Investment/investment';


@Injectable()
export class InvestmentService implements OnInit {
    Investment: Investment;
    Factors: InvestmentInfluenceFactor[];
    Risks: InvestmentRisk[];
    Groups: InvestmentGroup[];
    Regions: Region[];

    SelectedFactors: InvestmentInfluenceFactor[];
    SelectedRisks: InvestmentRisk[];
    SelectedGroups: InvestmentGroup[];
    SelectedRegions: Region[];

    constructor() {
        this.Investment = <Investment>
        {
            description: '',
            desirabilityStatement: '',
            factors: [],
            groups: [],
            id: 0,
            initialInvestment: 0,
            name: '',
            regions: [],
            risks: [],
            symbol: '£',
            value: 0,
            valueProposition: ''
        };
    }

}
