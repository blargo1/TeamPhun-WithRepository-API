using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TeamPhun_API.Models
{
    public class ColorTier
    {
        [Key]
        public string ColorTierId { get; set; }
        // number or colors
        public string Count { get; set;}
        //Make the ColorTier to be accessable through ColorTierId as a foreign key in ColorQuantityPrice table
        public virtual ICollection<ColorQuantityPrice> ColorQuantityPrices { get; set; }
    }
}