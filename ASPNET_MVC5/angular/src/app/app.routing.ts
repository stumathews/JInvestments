import { ModuleWithProviders } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { HomeComponent } from './Views/Home/home.component';
import { MessagesComponent } from './Views/Message/messages.component';
import { ModuleWithComponentFactories } from '@angular/core/src/linker/compiler';
import { InvestmentComponent } from './Views/Investment/investment.component';

const appRoutes: Routes = [
    { path : '', redirectTo: 'Home', pathMatch: 'full'},
    { path : 'Home', component: HomeComponent },
    { path : 'Messages', component: MessagesComponent },
    { path : 'Investments', component: InvestmentComponent }
    
];

export const APP_ROUTING: ModuleWithProviders = RouterModule.forRoot(appRoutes);
