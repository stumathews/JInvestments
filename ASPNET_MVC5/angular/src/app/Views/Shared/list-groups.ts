
import { Component, Input, OnInit, OnChanges, SimpleChanges, SimpleChange } from '@angular/core';
import { ApiService } from '../../apiservice.service';
import { InvestmentGroup } from '../../Models/InvestmentGroup';
import { GroupsLink } from '../../Models/Investment';
import { HtmlAction } from '../../Models/HtmlAction';
import { forEach } from '@angular/router/src/utils/collection';
import { EntityTypes } from '../../Utilities';

@Component({
  selector: 'app-list-groups',
  templateUrl: './list-groups.html'
})

export class ListGroupsComponent implements OnInit {
  Groups: InvestmentGroup[] = [];
  private _GroupLinks: GroupsLink[];
  @Input() ParentId: number;
  @Input()
  set GroupLinks(groups: GroupsLink[]) {
    groups.forEach((value, index, array) => {
      console.log('Attempting to get the real group for GroupLinks  ' + value.investmentGroupID);
      this.apiService.GetGroup(value.investmentGroupID)
      .subscribe(realGroup => this.Groups.push(realGroup), error => this.errorMessage = <any>error);
    });
    this._GroupLinks = groups;
  }
  get GroupLinks(): GroupsLink[] {
    return this._GroupLinks;
  }
  constructor(private apiService: ApiService) { }
  errorMessage: string;

  DissasociateEntityFromInvestment(entityId: number, parentId: number) {
    this.apiService
    .DissassociateEntityFromInvestment(EntityTypes.InvestmentGroup, entityId, parentId )
    .finally(() => {
      const toRemove = this.Groups.filter((each) => { if (each.id === entityId) { return each; } });
      const i = this.Groups.indexOf(toRemove[0]);
      this.Groups.splice(i, 1);
      this.ngOnInit();
    })
    .subscribe( code => console.log('code was' + code) , error => this.errorMessage = error);
  }
  ngOnInit(): void { }
}
