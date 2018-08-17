using System.Collections.Generic;
using TRBusinessLayer.DataObjects;
using TRBusinessLayer.Interfaces;

namespace TRBusinessLayer.DataAccessLayer
{
    public class TaxCadDal : ITaxCadDal
    {
        public List<CarbonFuelTax> GetTax502103A(int periodId, string glCode)
        {
            List<CarbonFuelTax> testData = new List<CarbonFuelTax>();
            CarbonFuelTax taxItem = new CarbonFuelTax { Completed=false, Jurisdiction = "CANB",AmtFreightTrain = 2320546,AmtWorkTrain=9580,AmtYardSwitching=11207,TotalLitres = 2341333,Adjustment=0,
                                                        TotalLitresToPay =2341333,RatePerLitre =(decimal)0.0430,TotalToPay=(decimal)-100677.32,PercDiff =(decimal)5.0};
            testData.Add(taxItem);
            taxItem = new CarbonFuelTax
            {
                Completed = true,
                Jurisdiction = "CAQC",
                AmtFreightTrain = 56106826,
                AmtWorkTrain = 0,
                AmtYardSwitching = 212922,
                TotalLitres = 5823604,
                Adjustment = 0,
                TotalLitresToPay = 58236043,
                RatePerLitre = (decimal)0.030,
                TotalToPay = (decimal)-174708.12,
                PercDiff= (decimal)11.0
            };
            testData.Add(taxItem);
            taxItem = new CarbonFuelTax
            {
                Completed = true,
                Jurisdiction = "CAon",
                AmtFreightTrain = 28539473,
                AmtWorkTrain = 21399,
                AmtYardSwitching = 567650,
                TotalLitres = 29128522,
                Adjustment = 0,
                TotalLitresToPay = 29128522,
                RatePerLitre = (decimal)0.0450,
                TotalToPay = (decimal)-1310783.49,
                PercDiff = (decimal)16.0
            };
            testData.Add(taxItem);
            return testData;
        }
        public List<FuelTaxDtl> GetTax502103ADtl(int periodId, string glCode)
        {
            List<FuelTaxDtl> testData = new List<FuelTaxDtl>();
            FuelTaxDtl taxDtl = new FuelTaxDtl { Jurisdiction = "CANB", TaxType = "FUEL", GlCode = "502103", VendorNo = "100400",TaxId="PBN04887714002", PayMethod = "T", DueDate = new System.DateTime(2018, 4, 24), DueDate2 = new System.DateTime(1900, 1, 1) };
            testData.Add(taxDtl);
            taxDtl = new FuelTaxDtl { Jurisdiction = "CANB", TaxType = "FUEL", GlCode = "502103", VendorNo = "105751", TaxId = "1000043156CA001", PayMethod = "T", DueDate = new System.DateTime(2018, 4, 24), DueDate2 = new System.DateTime(1900, 1, 1) };
            testData.Add(taxDtl);
            return testData;
        }
        public List<TaxItem> GetTax502563(int periodId,string glCode)
        {
            List<TaxItem> testData = new List<TaxItem>();
            TaxItem taxItem = new TaxItem();
            testData.Add(new TaxItem { TaxCode = "3B", TaxBase = (decimal)-417650.00, TaxAmount = (decimal)-29235.49, TaxAmtCalculated = (decimal)-29235.49, TaxToPay = 0, Note = "Sample Note" });
            testData.Add(new TaxItem { TaxCode = "4Z", TaxBase = (decimal)2703357, TaxAmount = (decimal)-144.83, TaxAmtCalculated = (decimal)-144.83, TaxToPay = 0, Note = "" });
             return testData;
        }
        public List<TaxItem> GetTax502009(int periodId, string glCode)
        {
            List<TaxItem> testData = new List<TaxItem>();
            TaxItem taxItem = new TaxItem();
            testData.Add(new TaxItem { TaxCode = "A2", TaxBase = (decimal)2596710.77, TaxAmount = (decimal)-181282.46, S4CalcAmount = 0, TaxToPay = (decimal)-181282.45, Note = "" });
            testData.Add(new TaxItem { TaxCode = "A4", TaxBase = (decimal)3931382.96, TaxAmount = (decimal)-275196.69, S4CalcAmount = 0, TaxToPay = (decimal)-275198.69, Note = "" });
            testData.Add(new TaxItem { TaxCode = "P4", TaxBase = (decimal)3782591.06, TaxAmount = (decimal)-264781.43, S4CalcAmount = 0, TaxToPay = (decimal)-264781.43, Note = "" });
            testData.Add(new TaxItem { TaxCode = "S4", TaxBase = (decimal)352583.82, TaxAmount = (decimal)-13222.10, S4CalcAmount = (decimal)11893.01, TaxToPay = (decimal)-11893.01, Note = "" });
            testData.Add(new TaxItem { TaxCode = "S4", TaxBase = (decimal)8889381.43, TaxAmount = (decimal)873.82, S4CalcAmount = 0, TaxToPay = 0, Note = "" });
            return testData;
        }
        public List<TaxRemCA> GetCATaxForPeriod(int periodId)
        {
            List<TaxRemCA> testData = new List<TaxRemCA>();

            var item = BuildRow("PST/State tax", "502009",
                (decimal)-733155.58, 3,
                (decimal)-1,0,
                (decimal)-149838.15, 3,
                (decimal)-473114.95, 3,
                (decimal)23, 0,
                (decimal)-1, 0,
                (decimal)20, 0,
                (decimal)-1, 0,
                (decimal)-1, 0,
                (decimal)20, 0,
                (decimal)23, 0);
            testData.Add(item);
            item = BuildRow("PST Other tax Pay", "502563",
                (decimal)-29182.32, 3,
                (decimal)-1, 0,
                (decimal)-22501.78, 3,
                (decimal)-4194.11, 3,
                (decimal)23, 0,
                (decimal)-1, 0,
                (decimal)20, 0,
                (decimal)-1, 0,
                (decimal)-1, 0,
                (decimal)20, 0,
                (decimal)23, 0);
            testData.Add(item);

            item = BuildRow("PST ISTA", "502010",
                 (decimal)-14430.47, 3,
                 (decimal)-1, 0,
                 (decimal)-28756.96, 3,
                 (decimal)-29788.02, 3,
                 (decimal)23, 2,
                 (decimal)-1, 0,
                 (decimal)20, 2,
                 (decimal)-1, 0,
                 (decimal)-1, 0,
                 (decimal)20, 0,
                 (decimal)23, 0);
            testData.Add(item);

            item = BuildRow("Fuel Tax", "502103",
                 (decimal)-743804.00, 3,
                 (decimal)-963936, 3,
                 (decimal)-2288340.14, 3,
                 (decimal)-650145.70, 3,
                 (decimal)-1310783.49, 3,
                 (decimal)-174708.12, 3,
                 (decimal)-1, 0,
                 (decimal)-100677.32, 3,
                 (decimal)-1579.58, 0,
                 (decimal)-1, 0,
                 (decimal)-13953.10, 0);
            testData.Add(item);
            item = BuildRow("Carbon Tax", "502103",
                (decimal)-1901660, 0,
                (decimal)-1559824.68, 0,
                (decimal)-1, 2,
                (decimal)-650145.70, 1,
                (decimal)-1310783.49, 2,
                (decimal)-174708.12, 0,
                (decimal)-1, 0,
                (decimal)-100677.32, 0,
                (decimal)-1579.58, 0,
                (decimal)-1, 0,
                (decimal)-13953.10, 0);
            testData.Add(item);

            return testData;
        }
        private TaxRemCA BuildRow(string taxDesc,string  glCode, decimal CABC,int CABCFlag, decimal CAAB, int CAABFlag,
                                                                 decimal CASK,int CASKFlag, decimal CAMB, int CAMBFlag,
                                                                 decimal CADN,int CADNFlag, decimal CAQC, int CAQCFlag,
                                                                 decimal CAPE,int CAPEFlag, decimal CANB, int CANBFlag,
                                                                 decimal CANT,int CANTFlag, decimal USMN, int USMNFlag,
                                                                 decimal CADON, int CADONFlag)
        {
            TaxRemCA item = new TaxRemCA();
            item.TaxDesc = taxDesc;
            item.GlCode = glCode;

            item.CABC = CABC;
            item.CABCFlag = CABCFlag;

            item.CAAB = CAAB;
            item.CAABFlag = CAABFlag;

            item.CASK = CASK;
            item.CASKFlag = CASKFlag;

            item.CAMB = CAMB;
            item.CAMBFlag = CAMBFlag;

            item.CADN = CADN;
            item.CADNFlag = CADNFlag;

            item.CAQC = CAQC;
            item.CAQCFlag = CAQCFlag;

            item.CAPE = CAPE;
            item.CAPEFlag = CAPEFlag;

            item.CANB = CANB;
            item.CANBFlag = CANBFlag;

            item.CANT = CANT;
            item.CANTFlag = CANTFlag;

            item.USMN = USMN;
            item.USMNFlag = USMNFlag;

            item.CADON = CADON;
            item.CADONFlag = CADONFlag;
            return item;
        }
    }
}