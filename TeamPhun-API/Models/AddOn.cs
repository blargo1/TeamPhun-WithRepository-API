using System;
using System.ComponentModel.DataAnnotations;

namespace TeamPhun_API.Models
{
    public class AddOn
    {
        //primary key
        [Key]
        public int AddOnId { get; set; }
        // product Details
        public double MetallicInks { get; set; }
        public double Discharge { get; set; }
        public double Foil { get; set; }
        public double Flash { get; set; }
        public double PMSColorMatching { get; set; }
        public double FoldingBagging { get; set; }
        public double SalesTax { get; set; }
        public double SetUp { get; set; }
        public DateTime AddOnUpdate { get; set; }

    }
}