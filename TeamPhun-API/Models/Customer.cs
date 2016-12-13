using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TeamPhun_API.Models
{
    public class Customer
    {
        //primary key
        [Key]
        public int CustomerId { get; set; }

        //Customer details
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Organization { get; set; }
        public string WebSite { get; set; }
        public string Role { get; set; }
        public string BusinessPhone { get; set; }
        public string MobilePhone { get; set; }
        public string OtherPhone { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int ZipCode { get; set; }
        public string Country { get; set; }
        public string Note { get; set; }
        public DateTime CustomerRecordCreated { get; set; }
        public DateTime UpdateCustomerRecord { get; set; }


        //Make the Customer to be accessable through customerId as a foreign key in Orders table
        public virtual ICollection<Order> Orders { get; set; }

    }
}