using System.ComponentModel.DataAnnotations;

namespace TeamPhun_API.Models
{
    public class Configuration
    {
        // primary key
        [Key]
        public string ConfigurationId { get; set; }

        //holds the price for the addictional print location color
        public string AddPrintLocationColorPrice { get; set; }
    }
}