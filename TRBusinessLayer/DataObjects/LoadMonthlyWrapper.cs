using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TRBusinessLayer.DataObjects
{
    public class LoadMonthlyWrapper : AbstractDto
    {
      public bool FileImported { get; set; }
      public  List<LogEntry> AvailLogEntries { get;set; }
    }
}