using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using TeamPhun_API.Models;

namespace TeamPhun_API.data
{
    public class TeamPhunDataContext : DbContext
    {
        private object _db;

        public TeamPhunDataContext() : base("TeamPhun")
        {
            this.Configuration.LazyLoadingEnabled = false;
            this.Configuration.ProxyCreationEnabled = false;
        }

        public IDbSet<Customer> Customers { get; set; }
        public IDbSet<Order> Orders { get; set; }
        public IDbSet<OrderLineItem> OrderLineItems { get; set; }
        public IDbSet<AddOn> AddOns { get; set; }
        public IDbSet<ColorTier> ColorTiers { get; set; }
        public IDbSet<QuantityTier> QuantityTiers { get; set; }
        public IDbSet<Configuration> Configurations { get; set; }
        public IDbSet<ColorQuantityPrice> ColorQuantityPrices { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            //It makes a compouned primary key in Order Table, It makes CustomerId available inside OrderLine Item 
            //modelBuilder.Entity<Order>().HasKey(x => new { x.OrderId, x.CustomerId });

            // a customer can haves many orders
            modelBuilder.Entity<Customer>()

                        .HasMany(c => c.Orders)
                        //store Customer in c alias name
                        //every customer has an order in orders table
                        .WithRequired(o => o.Customer)
                        //specifies that customerId is being used as a foregin key in the Orders table
                        .HasForeignKey(o => o.CustomerId);


            // an Order has many orderlineItems
            modelBuilder.Entity<Order>()
                        .HasMany(o => o.OrderLineItems)
                        .WithRequired(ol => ol.Order)
                        .HasForeignKey(ol => ol.OrderId);


            //compound key
            modelBuilder.Entity<ColorQuantityPrice>()
            .HasKey(cq => new { cq.ColorTierId, cq.QuantityTierId });


        }

    }
}