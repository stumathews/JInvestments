
import { Component, Input, OnInit, OnChanges, SimpleChanges, SimpleChange } from '@angular/core';
import { ApiService } from '../../apiservice.service';
import { Region } from '../../Models/Region';
import { RegionsLink } from '../../Models/Investment';
import { HtmlAction } from '../../Models/HtmlAction';
import { forEach } from '@angular/router/src/utils/collection';

@Component({
  selector: 'app-list-regions',
  templateUrl: './list-regions.html'
})

export class ListRegionsComponent implements OnInit {
  Regions: Region[] = [];
  private _RegionsLinks: RegionsLink[];
  @Input()
  set RegionLinks(Regions: RegionsLink[]) {
    Regions.forEach((value, index, risks) => {
      console.log('Attempting to get the Region for ' + value.regionID);
      this.apiService.GetRegion(value.regionID)
      .subscribe(realRegion => this.Regions.push(realRegion), error => this.errorMessage = <any>error);
    });
    this._RegionsLinks = Regions;
  }
  get RegionLinks(): RegionsLink[] {
    return this._RegionsLinks;
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
