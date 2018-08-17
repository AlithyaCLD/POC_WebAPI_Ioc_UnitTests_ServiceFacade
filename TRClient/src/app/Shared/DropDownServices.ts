import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse,   HttpParams, HttpHeaders } from '@angular/common/http';

import { Observable } from 'rxjs';
import {DropDownsWrapper} from '../Entities/DropDownsWrapper';

@Injectable()
export class DropDownServices
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
    getDropDownFrmDb(fromPeriodEnd: Date, typeOfDropDown: string): Observable<DropDownsWrapper>
    {
        
        let lheaders = new HttpHeaders({ 'Content-Type': 'application/json; charset=UTF-8', 'Accept-Language': 'en-US' });
    
        let txtDate = fromPeriodEnd.toISOString().substring(0,10);
      
        var completeUrl = this._baseUrl + "api/Dropdowns/" + txtDate + "/" + typeOfDropDown ;
      
        return this.http.get<DropDownsWrapper>(completeUrl, { headers: lheaders });

    }
}