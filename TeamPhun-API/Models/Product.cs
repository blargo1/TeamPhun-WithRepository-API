using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace TeamPhun_API.Models
{
    public class Product
    {
        //primary key
        [Key]
        public int ProductId { get; set; }
        // product Details
        public int ProductCode { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public double ProductCost { get; set; }
        public DateTime ProductCreatedDate { get; set; }


        //Make the Product to be accessable through productId as a foreign key in OrderLineItem table
        public virtual ICollection<OrderLineItem> OrderLineItems { get; set; }

    }
}