import { Injectable } from '@angular/core';
import { environment} from '../../environments/environment';

@Injectable()
export class ConstantsServices
{
    
    get getAvailPeriods() : number {
        return 1;
    }
    get getAvailStartPeriods() : number {
        return 2;
    }
    get getAvailEndPeriods() : number {
        return 3;
    }
    get getAvailTaxTypes() : number {
        return 4;
    }
    get getAvailVauchers() : number {
        return 5;
    }    
    get getCORSUrl() : string {
        if (environment.production) {
  
            return '';
         }
         else {
            return 'http://localhost:54710/';
         }
    }
}