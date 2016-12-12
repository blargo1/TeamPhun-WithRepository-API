using System;
using System.ComponentModel.DataAnnotations;

namespace TeamPhun_API.Models
{
    public class Price
    {
        //primary key
        [Key]
        public int PriceId { get; set; }

        //Details
        public int CategoryRange { get; set; }
        public double Tier { get; set; }
        public double ColorOne { get; set; }
        public double ColorTwo { get; set; }
        public double ColorThree { get; set; }
        public double ColorFour { get; set; }
        public double ColorFive { get; set; }
        public double ColorSix { get; set; }
        public double ColorSeven { get; set; }
        public double ColorEight { get; set; }
        public double ColorNine { get; set; }
        public double ColorTen { get; set; }
        public int  AdditionalColorCost { get; set; }
        public int PrintLocations { get; set; }
        public DateTime PriceUpdate { get; set; }


    }
}