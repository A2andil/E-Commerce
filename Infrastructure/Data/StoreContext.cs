using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Data
{
    public class StoreContext : DbContext
    {
        public StoreContext(DbContextOptions options) : base(options)
        {

        }

        public StoreContext()
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // You can globally assign schema here
            modelBuilder.HasDefaultSchema("Security");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //optionsBuilder.UseSqlServer("Server=sql5046.site4now.net;Database=DB_A40639_Ghonim;User Id=DB_A40639_Ghonim_admin;password=Ghonim@2000;Trusted_Connection=False;MultipleActiveResultSets=true;");
                optionsBuilder.UseSqlServer(@"Server =.; Database = souq_22; Trusted_Connection = True;MultipleActiveResultSets=true
");
            }
        }



        public DbSet<Product> Products { get; set; }
    }
}
