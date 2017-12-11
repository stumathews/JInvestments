
import { Component, Input, OnInit, OnChanges, SimpleChanges, SimpleChange } from '@angular/core';
import { ApiService } from '../../apiservice.service';
import { InvestmentInfluenceFactor } from '../../Models/InvestmentInfluenceFactor';
import { FactorsLink } from '../../Models/Investment';
import { HtmlAction } from '../../Models/HtmlAction';
import { forEach } from '@angular/router/src/utils/collection';

@Component({
  selector: 'app-list-factors',
  templateUrl: './list-factors.html'
})

export class ListFactorsComponent implements OnInit {
  Factors: InvestmentInfluenceFactor[] = [];
  private _FactorLinks: FactorsLink[];
  /* We get the RiskLink objects that are references to the risks via RiskIDs.
     So, lets use those IDs and get the full risks. */
  @Input()
  set FactorLinks(Factors: FactorsLink[]) {
    Factors.forEach((value, index, risks) => {
      console.log('Attempting to get the RealRisk for ' + value.investmentInfluenceFactorID);
      this.apiService.GetFactor(value.investmentInfluenceFactorID)
      .subscribe(realFactor => this.Factors.push(realFactor), error => this.errorMessage = <any>error);
    });
    this._FactorLinks = Factors;
  }
  get FactorLinks(): FactorsLink[] {
    return this._FactorLinks;
  }
  HtmlActions: HtmlAction[] = [ {
    id: 0,
    name: '',
    DisplayName: 'Dissassociate',
    LinkTitle: 'Dissassociate',
    ActionName: 'DissassociateRisk',
    ControllerName: 'DissassociateRisk'}
  ];
  constructor(private apiService: ApiService) { }
  errorMessage: string;

  ngOnInit(): void { }
}
