using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TeamPhun_API.Models
{
    public class QuantityTier
    {
        public int QuantityTierId { get; set; }
        public int MinQuantity { get; set; }
        public int MaxQuantity { get; set; }


        //Make the QuantityTierId to be accessable through QuantityTierId as a foreign key in ColorQuantityPrice table
        public virtual ICollection<ColorQuantityPrice> ColorQuantityPrices { get; set; }
        public object ColorTierId { get; internal set; }
    }
}