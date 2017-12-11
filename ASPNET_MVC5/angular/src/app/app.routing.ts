import { ModuleWithProviders } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ModuleWithComponentFactories } from '@angular/core/src/linker/compiler';

import { HomeComponent } from './Views/Home/home';
import { InvestmentComponent } from './Views/Investment/investment';
import { InvestmentDetailComponent } from './Views/Investment/investment.detail';
import { FactorComponent } from './Views/Factor/factor';
import { GroupComponent } from './Views/Group/group';
import { RiskComponent } from './Views/Risk/risk';
import { RegionComponent } from './Views/Region/region';

const appRoutes: Routes = [
    { path : '', redirectTo: 'Home', pathMatch: 'full'},
    { path : 'Home', component: HomeComponent },
    { path : 'Investments', component: InvestmentComponent },
    { path : 'InvestmentDetails/:id', component: InvestmentDetailComponent },
    { path : 'Factors', component: FactorComponent },
    { path : 'Groups', component: GroupComponent },
    { path : 'Risks', component: RiskComponent },
    { path : 'Regions', component: RegionComponent }
];

export const APP_ROUTING: ModuleWithProviders = RouterModule.forRoot(appRoutes);
