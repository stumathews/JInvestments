import { Component, OnInit, Input, Output, EventEmitter  } from '@angular/core';
import { ApiService } from '../../apiservice.service';
import { InvestmentGroup } from '../../Models/InvestmentGroup';
import { ActivatedRoute } from '@angular/router';
import { Location } from '@angular/common';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import {Router} from '@angular/router';
import { GetRequiredTextValidators, GetRequiredNumberValidators, EntityTypes } from '../../Utilities';
import { CheckModel } from '../../Models/CheckModel';



@Component({
  selector: 'app-select-items',
  templateUrl: 'select-items.html',
  })

export class SelectItemsComponent implements OnInit {
  constructor(private apiService: ApiService,
              private route: ActivatedRoute,
              private location: Location,
              private router: Router) { }
  ItemsType: EntityTypes;
  @Input() Items: CheckModel[];
  // @Output() ItemsChange: EventEmitter<CheckModel[]> = new EventEmitter<CheckModel[]>();
  ngOnInit(): void {
      /* Restore the checkmodel array for this item type */
  }

  onNext() {
      /* Store this type type's array*/
    console.log('On Next pressed');
  }



}
