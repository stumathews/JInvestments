import { Injectable } from '@angular/core';
import { Http, Response } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import { Investment } from './Views/Investment/investment';
import { InvestmentInfluenceFactor } from './Views/Factor/InvestmentInfluenceFactor';
import { FactorComponent } from './Views/Factor/factor.component';
import { GroupComponent } from './Views/Group/group.component';
import { RiskComponent } from './Views/Risk/risk.component';
import { InvestmentGroup } from './Views/Group/InvestmentGroup';
import { Region } from './Views/Region/Region';
import { InvestmentRisk } from './Views/Risk/InvestmentRisk';


@Injectable()
export class ApiService {

    Investments: Investment[];
    Factors: InvestmentInfluenceFactor[];
    Groups: InvestmentGroup[];
    Regions: Region[];

    private baseURL = 'http://localhost:49921/api';
    private InvestmentsUrlEndpoint = this.baseURL + '/Investment';
    private FactorsUrlEndpoint = this.baseURL + '/Factor';
    private GroupsUrlEndpoint = this.baseURL + '/Group';
    private RisksUrlEndpoint = this.baseURL + '/Risk';
    private RegionsUrlEndpoint = this.baseURL + '/Region';
    private InvestmentByIdUrlEndpoint = this.baseURL + '/Investment/{id}';
    constructor(private http: Http) { }

    GetInvestments(): Observable<Investment[]> {
        console.log('Getting investments...');
        return this.http.get(this.InvestmentsUrlEndpoint)
                        .map((response: Response) => <Investment[]>response.json())
                        .do((data => console.log('All: ' + JSON.stringify(data))))
                        .catch(this.handleError);
    }

    GetFactors(): Observable<InvestmentInfluenceFactor[]> {
        console.log('Getting factors...');
        return this.http.get(this.FactorsUrlEndpoint)
                        .map((response: Response) => <InvestmentInfluenceFactor[]>response.json())
                        .do((data => console.log('All: ' + JSON.stringify(data))))
                        .catch(this.handleError);
    }

    GetGroups(): Observable<InvestmentGroup[]> {
        console.log('Getting groups...');
        return this.http.get(this.GroupsUrlEndpoint)
                        .map((response: Response) => <InvestmentGroup[]>response.json())
                        .do((data => console.log('All: ' + JSON.stringify(data))))
                        .catch(this.handleError);
    }

    GetRisks(): Observable<InvestmentRisk[]> {
        console.log('Getting risks...');
        return this.http.get(this.RisksUrlEndpoint)
                        .map((response: Response) => <InvestmentRisk[]>response.json())
                        .do((data => console.log('All: ' + JSON.stringify(data))))
                        .catch(this.handleError);
    }

    GetRegions(): Observable<Region[]> {
        console.log('Getting regions...');
        return this.http.get(this.RegionsUrlEndpoint)
                        .map((response: Response) => <Region[]>response.json())
                        .do((data => console.log('All: ' + JSON.stringify(data))))
                        .catch(this.handleError);
    }

    GetInvestment(id): Observable<Investment> {
        console.log('Getting investment id=' + id);
        return this.http.get(this.InvestmentByIdUrlEndpoint.replace('{id}', id))
                        .map((response: Response) => <Investment>response.json())
                        .do((data => console.log('All: ' + JSON.stringify(data))))
                        .catch(this.handleError);
    }


    private handleError(error: Response) {
        console.error(error);
        return Observable.throw(error.json().error || 'server error');
    }
}
