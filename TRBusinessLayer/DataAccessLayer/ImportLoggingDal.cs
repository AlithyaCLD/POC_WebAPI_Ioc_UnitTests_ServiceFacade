using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TRBusinessLayer.DataObjects;
using TRBusinessLayer.Interfaces;

namespace TRBusinessLayer.DataAccessLayer
{
    public class ImportLoggingDal : IImportLoggingDal
    {
        public List<LogEntry> GetLogEntries()
        {
            List<LogEntry> sample = new List<LogEntry>();
            DateTime dt = new DateTime(2017, 07, 02, 8, 27, 36);
            sample.Add(new LogEntry { ImportType = "Import Fuel", ImportDate = dt, FileName = "File 1" });
            dt = new DateTime(2017, 07, 02, 8, 34, 36);
            sample.Add(new LogEntry { ImportType = "Import Fuel", ImportDate = dt, FileName = "File 2" });
            dt = new DateTime(2017, 07, 03, 11, 31, 36);
            sample.Add(new LogEntry { ImportType = "Import BSET", ImportDate = dt, FileName = "File 2" });
            return sample;
        }
    }
}