import { Component, OnInit, Input } from '@angular/core';
import { ApiService } from '../../apiservice.service';
import { InvestmentGroup } from '../../Models/InvestmentGroup';

@Component({
  selector: 'app-group',
  templateUrl: './group.html'
})
export class GroupComponent implements OnInit {
  Groups: InvestmentGroup[];
  constructor(private apiService: ApiService) { }

  errorMessage: string;
  ngOnInit(): void {
    this.apiService.GetGroups()
        .subscribe(groups => this.Groups = groups,
                   error => this.errorMessage = <any>error);
  }
}
