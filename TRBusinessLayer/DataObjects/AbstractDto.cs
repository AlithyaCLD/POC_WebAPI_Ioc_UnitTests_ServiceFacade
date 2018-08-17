using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TRBusinessLayer.DataObjects
{
    public class AbstractDto
    {
        public bool hasAnError { get; set; }
        public string message { get; set; }
        public string errMessage { get; set; }
        public string stackMessage { get; set; }
    }
}