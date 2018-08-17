using System;
using System.Collections.Generic;
using System.Linq;
using TRBusinessLayer.DataObjects;
using TRBusinessLayer.DataAccessLayer;


namespace TRBusinessLayer.Process
{
    public class LoadMonthly  
    {
        public LoadMonthlyWrapper GetLogEntries() 
        {
            LoadMonthlyWrapper loggingWrapper = new LoadMonthlyWrapper { hasAnError = false };
            try
            {
                ImportLoggingDal importLoggingDal = new ImportLoggingDal();
                loggingWrapper.AvailLogEntries = importLoggingDal.GetLogEntries();
            }
            catch (Exception ex)
            {
                loggingWrapper = new LoadMonthlyWrapper { hasAnError = true };
            }
            return loggingWrapper;
        }
        public LoadMonthlyWrapper ProcessMthlyLoad(int fileNo)
        {
            LoadMonthlyWrapper loggingWrapper = new LoadMonthlyWrapper { hasAnError = false };
            loggingWrapper.FileImported = true;
            return loggingWrapper;
        }
    }
}