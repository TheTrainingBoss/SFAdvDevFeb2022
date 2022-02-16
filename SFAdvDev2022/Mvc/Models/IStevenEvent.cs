using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telerik.Sitefinity.Services.Events;

namespace SFAdvDev2022.Mvc.Models
{
    public interface IStevenEvent: IEvent
    {
        string MyCustomMessage { get; set; }
    }
}
