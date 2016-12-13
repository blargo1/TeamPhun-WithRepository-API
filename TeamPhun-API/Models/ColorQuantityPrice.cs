using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TeamPhun_API.Models
{
    public class ColorQuantityPrice
    {
        //ForeignKey keys
        //foreign keys
      //  [Key]
      //  [Column(Order = 0)]
        public int ColorTierId { get; set; }

      //  [Key]
      //  [Column(Order = 1)]
        public int QuantityTierId { get; set; }

        ///price
        public double Price { get; set; }
        public DateTime PriceUpdate { get; set; }




        //Connecting Foreign keys
        public virtual ColorTier ColorTier { get; set; }
        public virtual QuantityTier QuantityTier { get; set; }
    }
}