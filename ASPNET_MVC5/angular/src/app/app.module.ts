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
import { ListGroupsComponent } from './Views/Shared/list-groups';
import { ListRegionsComponent } from './Views/Shared/list-regions';

@NgModule({
  declarations: [
    AppComponent, HomeComponent, SideNavComponent, InvestmentComponent,
    FactorComponent, GroupComponent, RiskComponent, RegionComponent, InvestmentDetailComponent,
    ListRiskComponent, ListFactorsComponent, ListGroupsComponent, ListRegionsComponent
  ],
  imports: [
    BrowserModule, APP_ROUTING, AlertModule.forRoot(), HttpModule
  ],
  providers: [ApiService],
  bootstrap: [AppComponent]
})
export class AppModule { }
