using System;
using System.Collections.Generic;


namespace TRBusinessLayer.DataObjects
{
    public class TaxReportWrapper : AbstractDto
    {      
        public List<DropDownItem> AvailTaxTypes { get; set; }
        public List<DropDownItem> AvailVoucherId { get; set; }
        public List<DropDownItem> AvailStartPeriod { get; set; }
        public List<DropDownItem> AvailEndPeriod { get; set; }
    }
}