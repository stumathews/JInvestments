import { Component, OnInit, Input } from '@angular/core';
import { ApiService } from '../../apiservice.service';
import { Investment } from '../../Models/investment';
import { ActivatedRoute , Router} from '@angular/router';
import { Location } from '@angular/common';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { InvestmentService } from '../../investment.service';



@Component({
  selector: 'app-new-investment',
  templateUrl: 'new-investment.html',
  })

export class NewInvestmentComponent implements OnInit {
  form;
  constructor(private apiService: ApiService,
              private route: ActivatedRoute,
              private location: Location,
              private router: Router,
              private investmentService: InvestmentService) { }
  Entity: Investment;
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
        name: new FormControl(this.investmentService.Investment.name, this.GetRequiredTextValidators()),
        description: new FormControl(this.investmentService.Investment.description, this.GetRequiredTextValidators()),
        symbol: new FormControl(this.investmentService.Investment.symbol, this.GetRequiredTextValidators()),
        valueProposition: new FormControl(this.investmentService.Investment.valueProposition, this.GetRequiredTextValidators()),
        desirabilityStatement: new FormControl(this.investmentService.Investment.desirabilityStatement, this.GetRequiredTextValidators()),
        initialInvestment: new FormControl(this.investmentService.Investment.initialInvestment, this.GetRequiredNumberValidators()),
        value: new FormControl(this.investmentService.Investment.value, this.GetRequiredNumberValidators()),
    });
  }

  onSubmit(form: Investment) {
    this.investmentService.Investment = form;
    this.router.navigateByUrl('/NewInvestmentWizard/(NewInvestmentWizardOutlet:SelectFactors)');

    /*
    this.apiService.CreateInvestment(form)
    .finally(() => {
      this.investmentService.Investment = form;
      this.router.navigateByUrl('/NewInvestmentWizard/(NewInvestmentWizardOutlet:SelectFactors)');

    })
    .subscribe( (value) => {
      console.log('received response: ' + JSON.stringify(value));
      this.investmentService.Investment = form;
    });
    */
  }
}
