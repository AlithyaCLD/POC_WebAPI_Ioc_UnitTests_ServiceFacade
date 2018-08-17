using System;

namespace TRBusinessLayer.DataObjects
{
    public class FuelTaxDtl
    {
        public string Jurisdiction { get; set; }
        public string TaxType { get; set; }
        public string GlCode { get; set; }
        public string VendorNo { get; set; }
        public string TaxId { get; set; }
        public string PayMethod { get; set; }
      
        public DateTime DueDate { get; set; }
        public DateTime DueDate2 { get; set; }
    }
}