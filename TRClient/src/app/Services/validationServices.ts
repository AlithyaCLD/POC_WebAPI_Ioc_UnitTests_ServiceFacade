import { Injectable } from '@angular/core';

@Injectable()
export class ValidationServices
{

    private isArray = Array.isArray || (<T>(x: any): x is T[] => x && typeof x.length === 'number');


    isNumeric(value: any)
    {
        return !this.isArray(value) && (value - parseFloat(value) + 1) >= 0;
    }
    isNumericReq(value: any, required: boolean)
    {
        if (value == '' && !required) {
            return true;
        }
        let hasNumeric = !this.isArray(value) && (value - parseFloat(value) + 1) >= 0;
        if (!hasNumeric)
        {
            return false;
        }
        let validNumber = Number(value);
        if (validNumber === 0 && required)
        {
            return false;
        }
        return true;
    }
    isNumericRange(value: any, lowervalue: number,upperValue: number)
    {
        let hasNumeric = !this.isArray(value) && (value - parseFloat(value) + 1) >= 0;
        if (!hasNumeric)
        {
            return false;
        }
        let validNumber = Number(value);
        if (validNumber >= lowervalue && validNumber <= upperValue)
        {
            return true;
        }
        return false;
    }
}