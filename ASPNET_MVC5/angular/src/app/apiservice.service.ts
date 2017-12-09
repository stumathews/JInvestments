import { Injectable } from '@angular/core';
import { Http, Response } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import { IInvestment } from './Views/Investment/investment';

@Injectable()
export class ApiService {

    Investments: IInvestment[];
    private InvestmentsUrlEndpoint = 'http://localhost:49921/api/Investment';
    constructor(private http: Http) {

    }

    GetInvestments(): Observable<IInvestment[]> {
        console.log('Getting investments...');
        return this.http.get(this.InvestmentsUrlEndpoint)
                        .map((response: Response) => <IInvestment[]>response.json())
                        .do((data => console.log('All: ' + JSON.stringify(data))))
                        .catch(this.handleError);
    }

    private handleError(error: Response) {
        console.error(error);
        return Observable.throw(error.json().error || 'server error');
    }
}
