using System;
using System.Collections.Generic;
using TRBusinessLayer.DataObjects;
using TRBusinessLayer.DataAccessLayer;

namespace TRBusinessLayer.Process
{
    public class ProcessTaxCA
    {
        public TaxWrapper GetCATaxForPeriod(int periodId)
        {
            TaxWrapper taxWrapper = new TaxWrapper { hasAnError = false };
            try
            {
                TaxCadDal taxCadDal = new TaxCadDal();
                taxWrapper.AvailTaxRemCA = taxCadDal.GetCATaxForPeriod(periodId);
            }
            catch (Exception ex)
            {
                taxWrapper = new TaxWrapper { hasAnError = true };
            }
            return taxWrapper;
        }
        public CarbonFuelTaxWrapper GetTax502103A(int periodId, string glCode)
        {
            CarbonFuelTaxWrapper taxWrapper = new CarbonFuelTaxWrapper { hasAnError = false };
            TaxCadDal taxCadDal = new TaxCadDal();
            taxWrapper.AvailFuelTax = taxCadDal.GetTax502103A(periodId, glCode);
            taxWrapper.AvailFuelTaxDtl = taxCadDal.GetTax502103ADtl(periodId, glCode);
            return taxWrapper;
        }
        public TaxWrapper GetTax502563(int periodId, string glCode)
        {
            TaxWrapper taxWrapper = new TaxWrapper { hasAnError = false };
            try
            {
                TaxCadDal taxCadDal = new TaxCadDal();
                taxWrapper.Company = "1000";
                taxWrapper.Vendor = "";
                taxWrapper.TaxId = "";
                taxWrapper.PaymentMethod = "";
                taxWrapper.DueDate = new DateTime(2018, 4, 30);
                taxWrapper.JurisdictionCode = "CABC";
                taxWrapper.DataEntryComplete = true;
                taxWrapper.CalcVendorCommission = (decimal)198;
                taxWrapper.DiffVsLastMthPaymnt = (decimal)18.04;
                taxWrapper.ValidationComplete = true;
                taxWrapper.JournalDifference = true;
                taxWrapper.CommissionNote = "Note for this commission";
                taxWrapper.AvailTaxItems = taxCadDal.GetTax502563(periodId, glCode);
            }
            catch (Exception ex)
            {
                taxWrapper = new TaxWrapper { hasAnError = true };
            }
            return taxWrapper;
        }
        public TaxWrapper GetTax502009(int periodId, string glCode)
        {
            TaxWrapper taxWrapper = new TaxWrapper { hasAnError = false };
            try
            {
                TaxCadDal taxCadDal = new TaxCadDal();
                taxWrapper.Company = "1000";
                taxWrapper.Vendor = "122750";
                taxWrapper.TaxId = "PST10005016";
                taxWrapper.PaymentMethod = "T";
                taxWrapper.DueDate = new DateTime(2018, 4, 30);
                taxWrapper.JurisdictionCode = "CABC";
                taxWrapper.DataEntryComplete = true;
                taxWrapper.PrevMthJourDiff = (decimal)873.82;
                taxWrapper.DiffVsLastMthPaymnt = (decimal)18.04;
                taxWrapper.ValidationComplete = true;
                taxWrapper.JournalDifference = true;
                taxWrapper.AvailTaxItems = taxCadDal.GetTax502009(periodId, glCode);
            }
            catch (Exception ex)
            {
                taxWrapper = new TaxWrapper { hasAnError = true };
            }
            return taxWrapper;
        }
    }
}