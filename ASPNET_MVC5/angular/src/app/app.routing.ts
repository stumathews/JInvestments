import { ModuleWithProviders } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { HomeComponent } from './Views/Home/home.component';
import { MessagesComponent } from './Views/Message/messages.component';
import { ModuleWithComponentFactories } from '@angular/core/src/linker/compiler';
import { InvestmentComponent } from './Views/Investment/investment.component';
import { InvestmentDetailComponent } from './Views/Investment/investment.detail.component';
import { FactorComponent } from './Views/Factor/factor.component';
import { GroupComponent } from './Views/Group/group.component';
import { RiskComponent } from './Views/Risk/risk.component';
import { RegionComponent } from './Views/Region/region.component';

const appRoutes: Routes = [
    { path : '', redirectTo: 'Home', pathMatch: 'full'},
    { path : 'Home', component: HomeComponent },
    { path : 'Messages', component: MessagesComponent },
    { path : 'Investments', component: InvestmentComponent },
    { path : 'InvestmentDetails/:id', component: InvestmentDetailComponent },
    { path : 'Factors', component: FactorComponent },
    { path : 'Groups', component: GroupComponent },
    { path : 'Risks', component: RiskComponent },
    { path : 'Regions', component: RegionComponent }
];

export const APP_ROUTING: ModuleWithProviders = RouterModule.forRoot(appRoutes);
