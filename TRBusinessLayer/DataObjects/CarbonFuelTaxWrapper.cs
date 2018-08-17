using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TRBusinessLayer.DataObjects;

namespace TRBusinessLayer.DataObjects
{
    public class CarbonFuelTaxWrapper : AbstractDto
    {

        public List<CarbonFuelTax> AvailFuelTax { get; set; }
        public List<FuelTaxDtl> AvailFuelTaxDtl { get; set; }
    }
}