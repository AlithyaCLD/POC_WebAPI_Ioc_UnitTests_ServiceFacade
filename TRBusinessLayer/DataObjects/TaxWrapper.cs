using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TRBusinessLayer.DataObjects
{
    public class TaxWrapper : AbstractDto
    {
        public int PeriodId { get; set; }
        public string Company { get; set; }
        public string Vendor { get; set; }
        public string PaymentMethod { get; set; }
        public DateTime DueDate { get; set; }
        public string JurisdictionCode { get; set; }
        public string TaxId { get; set; }
        public bool DataEntryComplete { get; set; }
        public bool ValidationComplete { get; set; }
        public bool JournalDifference { get; set; }
        public decimal PrevMthJourDiff { get; set; }
        public decimal DiffVsLastMthPaymnt { get; set; }
        
        public decimal CalcVendorCommission { get; set; }
        public string CommissionNote { get; set; }
        public List<TaxItem> AvailTaxItems { get; set; }       
        public List<TaxRemCA> AvailTaxRemCA { get; set; }
    }
}