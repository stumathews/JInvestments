
import { Component, Input, OnInit, OnChanges, SimpleChanges, SimpleChange } from '@angular/core';
import { ApiService } from '../../apiservice.service';
import { InvestmentRisk } from '../../Models/InvestmentRisk';
import { RisksLink } from '../../Models/Investment';
import { HtmlAction } from '../../Models/HtmlAction';
import { forEach } from '@angular/router/src/utils/collection';

@Component({
  selector: 'app-list-risks',
  templateUrl: './list-risks.html'
})

export class ListRiskComponent implements OnInit {
  Risks: InvestmentRisk[] = [];
  private _RiskLinks: RisksLink[];
  /* We get the RiskLink objects that are references to the risks via RiskIDs.
     So, lets use those IDs and get the full risks. */
  @Input()
  set RiskLinks(Risks: RisksLink[]) {
    Risks.forEach((value, index, risks) => {
      console.log('Attempting to get the RealRisk for ' + value.investmentRiskID);
      this.apiService.GetRisk(value.investmentRiskID)
      .subscribe(realRisk => this.Risks.push(realRisk), error => this.errorMessage = <any>error);
    });
    this._RiskLinks = Risks;
  }
  get RiskLinks(): RisksLink[] {
    return this._RiskLinks;
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
