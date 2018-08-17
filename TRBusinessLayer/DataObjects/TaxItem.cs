using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TRBusinessLayer.DataObjects
{
    public class TaxItem
    {
        public string TaxCode { get; set; }
        public decimal TaxBase { get; set; }
        public decimal TaxAmount { get; set; }
        public decimal S4CalcAmount { get; set; }
        public decimal TaxAmtCalculated { get; set; }
        public decimal Adjustments { get; set; }
        public decimal TaxToPay { get; set; }
        public string Note { get; set; }
    }
}