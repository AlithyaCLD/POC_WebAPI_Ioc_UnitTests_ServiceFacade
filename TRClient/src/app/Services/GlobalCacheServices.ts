import { Injectable } from '@angular/core';
import {DropDownItem}    from '../Entities/dropDownItem';


@Injectable()
export class GlobalCacheServices
{
    private _currdropDownItem: DropDownItem;
    private _baseUrl: string;
    private _currRptNo: number;
    private _currRptDesc: string;
    private _glCode: string
 
    set setGLCode(glCode: string)
    {
        this._glCode = glCode;
    }
    get getGLCode() : string {
        return this._glCode;
    }
    set setCurrRptNo(rptNo: number)
    {
        this._currRptNo = rptNo;
    }
    get getCurrRptNo() : number {
        return this._currRptNo;
    }
    set setCurrRptDesc(rptDesc: string)
    {
        this._currRptDesc = rptDesc;
    }
    get getCurrRptDesc() : string {
        return this._currRptDesc;
    }
    set setUrl(pUrl: string)
    {
        this._baseUrl = pUrl;  
    }
    set setCurrentPeriod(currdropDownItem: DropDownItem)
    {
        this._currdropDownItem = currdropDownItem;
    }
    get getCurrentPeriod() : DropDownItem {
         return this._currdropDownItem;
    }
    get getUrl() : string {
        return this._baseUrl;
    }
}