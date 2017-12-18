import { Component, OnInit, Input } from '@angular/core';
import { ApiService } from '../../apiservice.service';
import { Investment } from '../../Models/investment';
import { ActivatedRoute , Router} from '@angular/router';
import { Location } from '@angular/common';
import { FormGroup, FormControl, Validators } from '@angular/forms';



@Component({
  selector: 'app-new-investment',
  templateUrl: 'new-investment.html',
  })

export class NewInvestmentComponent implements OnInit {
  form;
  constructor(private apiService: ApiService,
              private route: ActivatedRoute,
              private location: Location,
              private router: Router) { }
  i: Investment;
  errorMessage: string;

  GetRequiredTextValidators() {
    return Validators.compose( [
      Validators.required,
      Validators.pattern('[\\w\\-\\s\\|$|£/]+')]);
   }

   GetRequiredNumberValidators() {
    return Validators.compose( [
      Validators.required,
      Validators.pattern('\\d+')]);
   }

  ngOnInit(): void {
      this.form = new FormGroup({
        name: new FormControl('', this.GetRequiredTextValidators()),
        description: new FormControl('', this.GetRequiredTextValidators()),
        symbol: new FormControl('£', this.GetRequiredTextValidators()),
        valueProposition: new FormControl('', this.GetRequiredTextValidators()),
        desirabilityStatement: new FormControl('', this.GetRequiredTextValidators()),
        initialInvestment: new FormControl('', this.GetRequiredNumberValidators()),
        value: new FormControl('', this.GetRequiredNumberValidators()),
    });
  }

  onSubmit(form: Investment) {
    this.apiService.CreateInvestment(form)
    .finally(() => {
      this.router.navigate(['/Investments']);
    })
    .subscribe( (value) => {
      console.log('received response: ' + JSON.stringify(value));
    });
  }
}
