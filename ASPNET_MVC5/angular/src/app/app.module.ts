import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpModule } from '@angular/http';
import { AlertModule } from 'ngx-bootstrap';
import { APP_ROUTING } from './app.routing';

import { AppComponent } from './Views/App/app.component';
import { HomeComponent } from './Views/Home/home.component';
import { MessagesComponent } from './Views/Message/messages.component';
import { SideNavComponent } from './Views/Shared/side-nav.component';
import { InvestmentComponent } from './Views/Investment/investment.component';

import { ApiService } from './apiservice.service';

@NgModule({
  declarations: [
    AppComponent, HomeComponent, MessagesComponent, SideNavComponent, InvestmentComponent
  ],
  imports: [
    BrowserModule, APP_ROUTING, AlertModule.forRoot(), HttpModule
  ],
  providers: [ApiService],
  bootstrap: [AppComponent]
})
export class AppModule { }
