import { Component, OnInit, Input } from '@angular/core';
import { ApiService } from '../../apiservice.service';
import { InvestmentGroup } from '../../Models/InvestmentGroup';
import { ActivatedRoute } from '@angular/router';
import { Location } from '@angular/common';

@Component({
  selector: 'app-group-details',
  templateUrl: './group-details.html'
})
export class GroupDetailsComponent implements OnInit {
  Group: InvestmentGroup;
  constructor(private apiService: ApiService, private route: ActivatedRoute, private location: Location) { }

  errorMessage: string;
  ngOnInit(): void {
    const id = +this.route.snapshot.paramMap .get('id');
    this.apiService.GetGroup(id).subscribe(group => this.Group = group,
                   error => this.errorMessage = <any>error);
  }
}
