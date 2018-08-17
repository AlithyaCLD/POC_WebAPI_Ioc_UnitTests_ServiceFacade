import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { Observable } from 'rxjs';


@Injectable()
export class UiOverRideServices
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
    getLegendColors(colorCode: number,textAlign: string) : any {
         
         //Not used any more!!

        var redColor = {'background-color': 'red','text-align':'right'};
        var yellowColor = {'background-color': 'yellow','text-align':'right'};
        var whiteColor = {'background-color': 'white','text-align':'right'};
        var lightGreenColor = {'background-color': 'lightgreen','text-align':'right'};

       
        switch (colorCode) {
            case 0:           // White
              return whiteColor;    
            case 1:           // Red                        
              return redColor;     
            case 2:           // Tax Calculated
                              
              return yellowColor;    
            case 3:           // mMVC Generated
                             
              return lightGreenColor
        }
       
    }
    
}