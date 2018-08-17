using System;

namespace TRBusinessLayer.DataObjects
{
    public class LogEntry
    {
        public string ImportType { get; set; }
        public DateTime ImportDate { get; set; }
        public string FileName { get; set; }
    }
}