import { Injectable } from '@angular/core';
import { HttpClient,  HttpHeaders } from '@angular/common/http';

import { Observable } from 'rxjs';
import {LoadMonthlyWrapper} from '../Entities/LoadMonthlyWrapper';

@Injectable()
export class LoadMonthlyServices
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
    getLogEntries(): Observable<LoadMonthlyWrapper>
    {
       
      
        let lheaders = new HttpHeaders({ 'Content-Type': 'application/json; charset=UTF-8', 'Authorization': 'token 848e137969be5ffd48796a1c940391caf3b9902b' });
     
        var completeUrl = this._baseUrl + 'api/LoadMonthly';
     
        return this.http.get<LoadMonthlyWrapper>(completeUrl, { headers: lheaders });

    }
    loadMthlyFiles(fileNo : number) : Observable<LoadMonthlyWrapper> {
        let lheaders = new HttpHeaders({ 'Content-Type': 'application/json; charset=UTF-8', 'Authorization': 'token 848e137969be5ffd48796a1c940391caf3b9902b' });
     
        var completeUrl = this._baseUrl + 'api/LoadMonthly/' + fileNo;
   
        return this.http.get<LoadMonthlyWrapper>(completeUrl, { headers: lheaders }); 
    }
}