import { Injectable } from '@angular/core';
import { Http, Response } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import { Investment } from './Models/investment';
import { InvestmentInfluenceFactor } from './Models/InvestmentInfluenceFactor';
import { FactorComponent } from './Views/Factor/factor';
import { GroupComponent } from './Views/Group/group';
import { RiskComponent } from './Views/Risk/risk';
import { InvestmentGroup } from './Models/InvestmentGroup';
import { Region } from './Models/Region';
import { InvestmentRisk } from './Models/InvestmentRisk';


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
    private RiskByIdUrlEndpoint = this.baseURL + '/Risk/{id}';
    private FactorByIdUrlEndpoint = this.baseURL + '/Factor/{id}';
    private GroupByIdUrlEndpoint = this.baseURL + '/Group/{id}';
    private RegionByIdUrlEndpoint = this.baseURL + '/Region/{id}';
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

    GetInvestment(id: number): Observable<Investment> {
        console.log('Getting investment id=' + id);
        return this.http.get(this.InvestmentByIdUrlEndpoint.replace('{id}', '' + id))
                        .map((response: Response) => <Investment>response.json())
                        .do((data => console.log('GetInvestment: ' + JSON.stringify(data))))
                        .catch(this.handleError);
    }

    GetRisk(id: number): Observable<InvestmentRisk> {
        console.log('Getting Risk id=' + id);
        return this.http.get(this.RiskByIdUrlEndpoint.replace('{id}', '' + id))
                        .map((response: Response) => <InvestmentRisk>response.json())
                        .do((data => console.log('GetRisk: ' + JSON.stringify(data))))
                        .catch(this.handleError);
    }

    GetFactor(id: number): Observable<InvestmentInfluenceFactor> {
        console.log('Getting Risk id=' + id);
        return this.http.get(this.FactorByIdUrlEndpoint.replace('{id}', '' + id))
                        .map((response: Response) => <InvestmentInfluenceFactor>response.json())
                        .do((data => console.log('GetRisk: ' + JSON.stringify(data))))
                        .catch(this.handleError);
    }

    GetGroup(id: number): Observable<InvestmentGroup> {
        console.log('Getting Group id=' + id);
        return this.http.get(this.GroupByIdUrlEndpoint.replace('{id}', '' + id))
                        .map((response: Response) => <InvestmentGroup>response.json())
                        .do((data => console.log('GetRisk: ' + JSON.stringify(data))))
                        .catch(this.handleError);
    }

    GetRegion(id: number): Observable<Region> {
        console.log('Getting Region id=' + id);
        return this.http.get(this.RegionByIdUrlEndpoint.replace('{id}', '' + id))
                        .map((response: Response) => <Region>response.json())
                        .do((data => console.log('GetRisk: ' + JSON.stringify(data))))
                        .catch(this.handleError);
    }


    private handleError(error: Response) {
        console.error(error);
        return Observable.throw(error.json().error || 'server error');
    }
}
