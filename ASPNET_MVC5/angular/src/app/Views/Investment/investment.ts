import { Component, OnInit, Input } from '@angular/core';
import { ApiService } from '../../apiservice.service';
import { Investment } from '../../Models/investment';
import { InvestmentDetailComponent } from './investment.detail';
import { EntityTypes  } from '../../Utilities';

@Component({
  selector: 'app-investment',
  templateUrl: './investment.html'
})
export class InvestmentComponent implements OnInit {
  title = 'Home';
  Investments: Investment[];
  constructor(private apiService: ApiService) { }

  errorMessage: string;
  public delete(id: string) {
    console.log('deleting id=' + id);
    this.apiService.DeleteEntity(EntityTypes.Investment, +id)
                    .finally(() => {
                      this.ngOnInit();
                    })
                   .subscribe(entity => console.log(JSON.stringify(entity)),
                              error => this.errorMessage = <any>error);
  }
  ngOnInit(): void {
    this.apiService.GetInvestments().subscribe(investments => {
      this.Investments = investments;
      /* For each investment, go and get the fat regions, risks, factors, groups etc.
         This allows us to show the detail on this page. It'sa bit wasteful perhaps because we
         dont pass these objects to the 'details' page or each of these objects and instead
         just fetch them again then, but for now, we'll do this until we pass the objects to the appropriate
         details page for each type of object
      */
      investments.forEach((investment, iindex) => {
        investment.factors.forEach((factor, findex) => {
          this.apiService.GetFactor(factor.investmentInfluenceFactorID).subscribe( result => {
            factor.investmentInfluenceFactor = result;
          }, error => this.errorMessage = <any>error);
        });
        investment.risks.forEach((risk, riskIndex) => {
          this.apiService.GetRisk(risk.investmentRiskID).subscribe( result => {
            risk.investmentRisk = result;
          }, error => this.errorMessage = <any>error);
        });
        investment.regions.forEach((region, regionIndex) => {
          this.apiService.GetRegion(region.regionID).subscribe( result => {
            region.region = result;
          }, error => this.errorMessage = <any>error);
        });
        investment.groups.forEach((group, gindex) => {
          this.apiService.GetGroup(group.investmentGroupID).subscribe( result => {
            group.investmentGroup = result;
          }, error => this.errorMessage = <any>error);
        });
      });
    }, error => this.errorMessage = <any>error);
  }
}
