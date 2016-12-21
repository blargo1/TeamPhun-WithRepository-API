using System;
using System.ComponentModel.DataAnnotations;

namespace TeamPhun_API.Models
{
    public class OrderLineItem
    {
        //Primary key
        [Key]
        public int OrderLineItemId { get; set; }

        //ForeignKey keys
        public int OrderId { get; set; }
       // public int VendorId { get; set; }
        //public int ProductId { get; set; }

        // Details
        public string Description { get; set; }
        public int TotalPieces { get; set; }
        public int TotalNumberColors { get; set; }
        public int NumberPrintLocations { get; set; }
        public bool MetallicLinks { get; set; }
        public bool Discharge { get; set; }
        public bool Foil { get; set; }
        public bool PMSColorMatching { get; set; }
        public bool Flash { get; set; }
        public bool FoldingAndBagging { get; set; }
        public bool SalesTax { get; set; }
        public bool SetUp { get; set; }
        public float OrderLineItemCost { get; set; } //it is the number of pieces plus services into CasePrice
        public float ProfitMargin { get; set; }
        public double OrderLineItemClientEstimate { get; set; }
        public double OrderLineItemProfit { get; set; }
        public DateTime OrderLineItemCreatedDate { get; set; }
        //store porduct details getting from SAS API
        public string VendorName { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string BrandName { get; set; }
        public int StyleId { get; set; }
        public string CasePrice { get; set; }
        public string StyleTitle { get; set; }


        //Connecting Foreign keys
        public virtual Order Order { get; set; }
     //   public virtual Product Product { get; set; }
      //  public virtual Vendor Vendor { get; set; }


    }
}