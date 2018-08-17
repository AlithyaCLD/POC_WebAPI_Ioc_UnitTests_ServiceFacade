import { Injectable }               from '@angular/core';
import { HttpClient,  HttpHeaders } from '@angular/common/http';

import { Observable }               from 'rxjs';
import {TaxWrapper}                 from '../Entities/TaxWrapper';
import { CarbonFuelTaxWrapper}      from '../Entities/CarbonFuelTaxWrapper';
@Injectable()
export class TaxRemittanceCAServices
{
    private _baseUrl = '/';  // URL to web api
   
    constructor( private http: HttpClient)
    {

        
    }
    set setHttp(phttp: HttpClient)
    {
        this.http = phttp;
    }
    set setUrl(pUrl: string)
    {
        this._baseUrl = pUrl; 
    }
    getRemCAForPeriod(periodId: number): Observable<TaxWrapper>
    {
       debugger;

        let lheaders = new HttpHeaders({ 'Content-Type': 'application/json; charset=UTF-8', 'Authorization': 'token 848e137969be5ffd48796a1c940391caf3b9902b' });
     
        var completeUrl = this._baseUrl + 'api/ProcessTaxCA/' + periodId;
     
        return this.http.get<TaxWrapper>(completeUrl, { headers: lheaders });

    }
    GetTaxDetails(periodId: number,glCode: string): Observable<TaxWrapper>
    {
         
        let lheaders = new HttpHeaders({ 'Content-Type': 'application/json; charset=UTF-8', 'Authorization': 'token 848e137969be5ffd48796a1c940391caf3b9902b' });
     
        var completeUrl = this._baseUrl + 'api/ProcessTaxCA/' + periodId + '/' + glCode;
     
        return this.http.get<TaxWrapper>(completeUrl, { headers: lheaders });

    }
    getTax502103(periodId: number,glCode: string): Observable<CarbonFuelTaxWrapper>
    {
        let lheaders = new HttpHeaders({ 'Content-Type': 'application/json; charset=UTF-8', 'Authorization': 'token 848e137969be5ffd48796a1c940391caf3b9902b' });
     
        var completeUrl = this._baseUrl + 'api/ProcessTaxCA/' + periodId + '/' + glCode + '/1';
     
        return this.http.get<CarbonFuelTaxWrapper>(completeUrl, { headers: lheaders });

    }
  
}