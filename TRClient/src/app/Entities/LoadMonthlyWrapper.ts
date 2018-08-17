import {LoadMonthlyItem} from './LoadMonthlyItem';
import {Awrapper}        from './Awrapper';

export class LoadMonthlyWrapper extends Awrapper {
   
    AvailLogEntries: LoadMonthlyItem[] = [];
    FileImported: number = -1;
  
 }