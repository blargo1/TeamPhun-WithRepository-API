using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TeamPhun_API.Models
{
    public class Configuration
    {
        // primary key
       public string  ConfigurationId { get; set; }

        //holds the price for the addictional print location color
        public string AddPrintLocationColorPrice { get; set; }
    }
}