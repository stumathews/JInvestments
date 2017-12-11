
import { Component, Input, OnInit, OnChanges, SimpleChanges, SimpleChange } from '@angular/core';
import { ApiService } from '../../apiservice.service';
import { InvestmentGroup } from '../../Models/InvestmentGroup';
import { GroupsLink } from '../../Models/Investment';
import { HtmlAction } from '../../Models/HtmlAction';
import { forEach } from '@angular/router/src/utils/collection';

@Component({
  selector: 'app-list-groups',
  templateUrl: './list-groups.html'
})

export class ListGroupsComponent implements OnInit {
  Groups: InvestmentGroup[] = [];
  private _GroupLinks: GroupsLink[];
  @Input()
  set GroupLinks(Factors: GroupsLink[]) {
    Factors.forEach((value, index, risks) => {
      console.log('Attempting to get the RealRisk for ' + value.investmentGroupID);
      this.apiService.GetGroup(value.investmentGroupID)
      .subscribe(realGroup => this.Groups.push(realGroup), error => this.errorMessage = <any>error);
    });
    this._GroupLinks = Factors;
  }
  get GroupLinks(): GroupsLink[] {
    return this._GroupLinks;
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
