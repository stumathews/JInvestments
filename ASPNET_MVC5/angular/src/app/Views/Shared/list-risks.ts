
import { Component, Input, OnInit, OnChanges, SimpleChanges, SimpleChange } from '@angular/core';
import { ApiService } from '../../apiservice.service';
import { InvestmentRisk } from '../../Models/InvestmentRisk';
import { RisksLink } from '../../Models/Investment';
import { HtmlAction } from '../../Models/HtmlAction';
import { forEach } from '@angular/router/src/utils/collection';
import { EntityTypes } from '../../Utilities';

@Component({
  selector: 'app-list-risks',
  templateUrl: './list-risks.html'
})

export class ListRiskComponent implements OnInit {
  Risks: InvestmentRisk[] = [];
  private _RiskLinks: RisksLink[];
  /* We get the RiskLink objects that are references to the risks via RiskIDs.
     So, lets use those IDs and get the full risks. */
  @Input() ParentId: number;
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

  constructor(private apiService: ApiService) { }
  errorMessage: string;

  DissasociateEntityFromInvestment(entityId: number, parentId: number) {
    this.apiService
    .DissassociateEntityFromInvestment(EntityTypes.InvestmentRisk, entityId, parentId )
    .finally(() => {
      const toRemove = this.Risks.filter((each) => { if (each.id === entityId) { return each; } });
      const i = this.Risks.indexOf(toRemove[0]);
      this.Risks.splice(i, 1);
      this.ngOnInit();
    })
    .subscribe( code => console.log('code was' + code) , error => this.errorMessage = error);
  }

  ngOnInit(): void { }
}
