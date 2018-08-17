import {DropDownItem} from './dropDownItem';
import {Awrapper}     from './Awrapper';

export class TaxReportWrapper extends Awrapper  {
 
    AvailTaxTypes: DropDownItem[];

    AvailVoucherId: DropDownItem[];
    AvailStartPeriod: DropDownItem[];
    AvailEndPeriod: DropDownItem[];
}