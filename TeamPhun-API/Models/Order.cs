using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TeamPhun_API.Models
{
    public class Order
    {
        //primary key
        [Key]
        public int OrderId { get; set; }

        // customerId as a foreign key
        public int CustomerId { get; set; }

        //Order details
        public double OrderTotal { get; set; }
        public double TotalCost { get; set; }
        public double TotalProfit { get; set; }
        public bool OrderStatus { get; set; }
        public DateTime OrderCreatedDate { get; set; }
        //Access Customer table using foreign key CustomerId
        public virtual Customer Customer { get; set; }


        //Make the Order to be accessable through OrderId as a foreign key in OrderLineItems table
        public virtual ICollection<OrderLineItem> OrderLineItems { get; set; }
    }
}