import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse,   HttpParams, HttpHeaders } from '@angular/common/http';

import { Observable }     from 'rxjs';
import {TaxReportWrapper} from '../Entities/TaxReportWrapper';

@Injectable()
export class TaxReportServices
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
        this._baseUrl = pUrl; // 'http://localhost:54710/';
    }
    getDropDownFrmDbC(fromPeriodEnd: Date): Observable<TaxReportWrapper>
    {
    
        let lheaders = new HttpHeaders({ 'Content-Type': 'application/json; charset=UTF-8', 'Accept-Language': 'en-US' });
    
        let txtDate = fromPeriodEnd.toISOString().substring(0,10);
         
        var completeUrl = this._baseUrl + "api/TaxAmountRpt/" + txtDate ;
      
        return this.http.get<TaxReportWrapper>(completeUrl, { headers: lheaders });

    }
}