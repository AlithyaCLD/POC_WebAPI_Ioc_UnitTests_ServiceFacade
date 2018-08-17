using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TRBusinessLayer.DataObjects;

namespace TRBusinessLayer.Interfaces
{
    public interface IImportLoggingDal
    {
        List<LogEntry> GetLogEntries();
    }
}
