using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace CookerAPI.Models
{
    public class CookerAPIContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public CookerAPIContext() : base("name=CookerAPIContext")
        {

            this.Database.Log = s => System.Diagnostics.Debug.WriteLine(s);
        }

        public System.Data.Entity.DbSet<CookerAPI.Models.Recipe> Recipes { get; set; }

        public System.Data.Entity.DbSet<CookerAPI.Models.Category_Main> Categories_Main { get; set; }

        public System.Data.Entity.DbSet<CookerAPI.Models.Category> Categories { get; set; }

        public System.Data.Entity.DbSet<CookerAPI.Models.Category_Recipe> Categories_Recipes { get; set; }

        public System.Data.Entity.DbSet<CookerAPI.Models.User> Users { get; set; }

        public System.Data.Entity.DbSet<CookerAPI.Models.Product> Products { get; set; }

        public System.Data.Entity.DbSet<CookerAPI.Models.Element> Elements { get; set; }

        public System.Data.Entity.DbSet<CookerAPI.Models.Comment> Comments { get; set; }

        public System.Data.Entity.DbSet<CookerAPI.Models.List> Lists{ get; set; }

        public System.Data.Entity.DbSet<CookerAPI.Models.Black_Item> Black_Items{ get; set; }

        public System.Data.Entity.DbSet<CookerAPI.Models.Rate> Rates { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

        }


    }
}
