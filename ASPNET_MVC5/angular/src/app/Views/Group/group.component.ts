import { Component } from '@angular/core';
import { ApiService } from '../../apiservice.service';
import { InvestmentGroup } from './InvestmentGroup';

@Component({
  selector: 'app-group',
  templateUrl: './group.component.html'
})
export class GroupComponent {
  Groups: InvestmentGroup[];
  constructor(private apiService: ApiService) { }

  errorMessage: string;
  ngOnInit(): void {
    this.apiService.GetGroups()
        .subscribe(groups => this.Groups = groups,
                   error => this.errorMessage = <any>error);
  }
}
