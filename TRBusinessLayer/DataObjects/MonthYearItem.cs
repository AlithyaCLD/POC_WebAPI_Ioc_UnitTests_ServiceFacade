using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TRBusinessLayer.DataObjects
{
    public class MonthYearItem
    {
        public int Id { get; set; }
        public string Period { get; set; }
        public int Total { get; set; }
        public int CanBeDeleted { get; set; }
    }
}