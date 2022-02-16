using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SFAdvDev2022.Mvc.Models
{
    public class StevenEvent : IStevenEvent
    {
        public string MyCustomMessage { get; set; }
        public string Origin { get; set; }
    }
}