using System;
using System.Collections.Generic;
using System.Linq;
 

namespace TRBusinessLayer.DataObjects
{
    public class DropDownsWrapper : AbstractDto
    {

        public List<DropDownItem> AvailDropDownItems { get; set; }
    }
}