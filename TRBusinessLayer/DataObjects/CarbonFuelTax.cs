using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TRBusinessLayer.DataObjects
{
    public class CarbonFuelTax
    {
        public bool Completed { get; set; }
        public string Jurisdiction { get; set; }
        public decimal AmtFreightTrain { get; set; }
        public decimal AmtWorkTrain { get; set; }
        public decimal AmtYardSwitching { get; set; }
        public decimal AmtTotalLine { get; set; }
        public decimal Adjustment { get; set; }
        public decimal TotalLitresToPay { get; set; }
        public decimal RatePerLitre { get; set; }
        public decimal TotalToPay { get; set; }
        public decimal PercDiff { get; set; }

        public decimal TotalLitres{get; set;}
    }
}