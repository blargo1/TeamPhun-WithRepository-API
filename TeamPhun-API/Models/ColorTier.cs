using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TeamPhun_API.Models
{
    public class ColorTier
    {
        [Key]
        public int ColorTierId { get; set; }
        // number or colors
        public int Count { get; set; }
        //Make the ColorTier to be accessable through ColorTierId as a foreign key in ColorQuantityPrice table
        public virtual ICollection<ColorQuantityPrice> ColorQuantityPrices { get; set; }
    }
}