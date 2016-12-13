using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace TeamPhun_API.Models
{
    public class Vendor
    {
        //primary key
        [Key]
        public int VendorId { get; set; }

        //Vendor Details
        public string VendorName { get; set; }
        public int VendorProductCode { get; set; }
        public string VendorInfo { get; set; }

        //Make the vendor to be accessable through VendorId as a foreign key in OrderLineItem table
        public virtual ICollection<OrderLineItem> OrderLineItems { get; set; }


    }
}