import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpModule } from '@angular/http';
import { AlertModule } from 'ngx-bootstrap';
import { APP_ROUTING } from './app.routing';

import { AppComponent } from './Views/App/app';
import { HomeComponent } from './Views/Home/home';
import { SideNavComponent } from './Views/Shared/side-nav';
import { InvestmentComponent } from './Views/Investment/investment';
import { FactorComponent } from './Views/Factor/factor';
import { GroupComponent } from './Views/Group/group';
import { RiskComponent } from './Views/Risk/risk';
import { RegionComponent } from './Views/Region/region';
import { InvestmentDetailComponent } from './Views/Investment/investment.detail';
import { ApiService } from './apiservice.service';
import { ListRiskComponent } from './Views/Shared/list-risks';
import { ListFactorsComponent } from './Views/Shared/list-factors';
import { ListInvestmentsComponent } from './Views/Shared/list-investments';
import { ListGroupsComponent } from './Views/Shared/list-groups';
import { ListRegionsComponent } from './Views/Shared/list-regions';
import { FactorDetailsComponent } from './Views/Factor/factor-details';
import { GroupDetailsComponent } from './Views/Group/group-details';
import { RegionDetailsComponent } from './Views/Region/region-details';
import { RiskDetailsComponent } from './Views/Risk/risk-details';
import { ReactiveFormsModule } from '@angular/forms';
import { NewInvestmentComponent } from './Views/Investment/new-investment';
import { NewFactorComponent } from './Views/Factor/new-factor';
import { NewGroupComponent } from './Views/Group/new-group';
import { NewRegionComponent } from './Views/Region/new-region';
import { NewRiskComponent } from './Views/Risk/new-risk';

@NgModule({
  declarations: [
    AppComponent, HomeComponent, SideNavComponent, InvestmentComponent,
    FactorComponent, GroupComponent, RiskComponent, RegionComponent, InvestmentDetailComponent,
    ListRiskComponent, ListFactorsComponent, ListGroupsComponent, ListRegionsComponent,
    FactorDetailsComponent, GroupDetailsComponent, RegionDetailsComponent, ListInvestmentsComponent,
    RiskDetailsComponent, NewInvestmentComponent, NewFactorComponent, NewGroupComponent,
    NewRegionComponent, NewRiskComponent
  ],
  imports: [
    BrowserModule, APP_ROUTING, AlertModule.forRoot(), HttpModule, ReactiveFormsModule
  ],
  providers: [ApiService],
  bootstrap: [AppComponent]
})
export class AppModule { }
