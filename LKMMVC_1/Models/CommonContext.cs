using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using LKMMVC_1.Models.EntityTypeConfiguration;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace LKMMVC_1.Models
{
    public class CommonContext:DbContext
    {
        public CommonContext() : base("CommonDatabase")
        {

        }

        
        public DbSet<News> News { get; set; }
        public DbSet<NewsPhoto> NewsPhotos { get; set; }
        public DbSet<ManagementBiography> ManagementBiographies { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new NewsPhotoConfiguration());




            //kad automatiskai nekurtu daugiskaitiniu pavadinimu
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
        }

    }
}