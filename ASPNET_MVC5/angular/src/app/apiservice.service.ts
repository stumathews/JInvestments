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
import { EntityTypes  } from './Utilities';


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

    CreateInvestment(investment: Investment): Observable<Investment> {
        console.log('CreateInvestment...' + JSON.stringify(investment));
        return this.http.post(this.InvestmentsUrlEndpoint, investment)
            .map((response: Response) => <Investment>response.json())
            .do( (data => console.log('do CreateInvestment: ' + JSON.stringify(data))))
            .catch(this.handleError);
    }

    CreateInvestmentInfluenceFactor(factor: InvestmentInfluenceFactor): Observable<InvestmentInfluenceFactor> {
        console.log('CreateInvestmentInfluenceFactor...' + JSON.stringify(factor));
        return this.http.post(this.FactorsUrlEndpoint, factor)
        .map((response: Response) => <InvestmentInfluenceFactor>response.json())
        .do( (data => console.log('do CreateInvestmentInfluenceFactor: ' + JSON.stringify(data))))
        .catch(this.handleError);
    }

    CreateInvestmentGroup(group: InvestmentGroup): Observable<InvestmentGroup> {
        console.log('CreateInvestmentGroup...' + JSON.stringify(group));
        return this.http.post(this.GroupsUrlEndpoint, group)
        .map((response: Response) => <InvestmentGroup>response.json())
        .do( (data => console.log('do CreateInvestmentGroup: ' + JSON.stringify(data))))
        .catch(this.handleError);
    }

    CreateInvestmentRisk(risk: InvestmentRisk): Observable<InvestmentRisk> {
        console.log('CreateRisk...' + JSON.stringify(risk));
        return this.http.post(this.RisksUrlEndpoint, risk)
        .map((response: Response) => <InvestmentRisk>response.json())
        .do( (data => console.log('do CreateRisk: ' + JSON.stringify(data))))
        .catch(this.handleError);
    }

    CreateRegion(region: Region): Observable<Region> {
        console.log('CreateRegion...' + JSON.stringify(region));
        return this.http.post(this.RegionsUrlEndpoint, region)
        .map((response: Response) => <Region>response.json())
        .do( (data => console.log('do CreateRegion: ' + JSON.stringify(data))))
        .catch(this.handleError);
    }

    DeleteEntity(entityType: EntityTypes, id: number): Observable<any>  {
        let mapFunction;
        let url;

        if (entityType === EntityTypes.Investment) {
            url =  this.InvestmentByIdUrlEndpoint.replace('{id}', '' + id);
            mapFunction = (response: Response) => <Region>response.json();
        } else if (entityType === EntityTypes.InvestmentInfluenceFactor) {
            url =  this.FactorByIdUrlEndpoint.replace('{id}', '' + id);
            mapFunction = (response: Response) => <InvestmentInfluenceFactor>response.json();
        } else if (entityType === EntityTypes.InvestmentRisk) {
            url =  this.RiskByIdUrlEndpoint.replace('{id}', '' + id);
            mapFunction = (response: Response) => <InvestmentRisk>response.json();
        } else if (entityType === EntityTypes.InvestmentGroup) {
            url =  this.GroupByIdUrlEndpoint.replace('{id}', '' + id);
            mapFunction = (response: Response) => <InvestmentGroup>response.json();
        } else if (entityType === EntityTypes.Region) {
            url =  this.RegionByIdUrlEndpoint.replace('{id}', '' + id);
            mapFunction = (response: Response) => <Region>response.json();
        }

        console.log('Delete entity via url:' + url);
        return this.http.delete(url).map(mapFunction)
        .do((data => console.log('do DeleteEntity: ' + JSON.stringify(data))))
        .catch(this.handleError);
    }

    private handleError(error: Response) {
        console.error(error);
        return Observable.throw(error.json().error || 'server error');
    }
}
