
import { Component, Input, OnInit, OnChanges, SimpleChanges, SimpleChange } from '@angular/core';
import { ApiService } from '../../apiservice.service';
import { Region } from '../../Models/Region';
import { RegionsLink } from '../../Models/Investment';
import { HtmlAction } from '../../Models/HtmlAction';
import { forEach } from '@angular/router/src/utils/collection';
import { EntityTypes } from '../../Utilities';

@Component({
  selector: 'app-list-regions',
  templateUrl: './list-regions.html'
})

export class ListRegionsComponent implements OnInit {
  Regions: Region[] = [];
  private _RegionsLinks: RegionsLink[];
  @Input() ParentId: number;
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

  DissasociateEntityFromInvestment(entityId: number, parentId: number) {
    this.apiService
    .DissassociateEntityFromInvestment(EntityTypes.Region, entityId, parentId )
    .finally(() => {
      const toRemove = this.Regions.filter((each) => { if (each.id === entityId) { return each; } });
      const i = this.Regions.indexOf(toRemove[0]);
      this.Regions.splice(i, 1);
      this.ngOnInit();
    })
    .subscribe( code => console.log('code was' + code) , error => this.errorMessage = error);
  }
  constructor(private apiService: ApiService) { }
  errorMessage: string;

  ngOnInit(): void { }
}
