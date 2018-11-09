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


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new NewsPhotoConfiguration());




            //kad automatiskai nekurtu daugiskaitiniu pavadinimu
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
        }

        public System.Data.Entity.DbSet<LKMMVC_1.Models.NewsPhoto> NewsPhotoes { get; set; }

        public System.Data.Entity.DbSet<LKMMVC_1.Models.Biography> Biographies { get; set; }

        public System.Data.Entity.DbSet<LKMMVC_1.Models.Education> Educations { get; set; }
    }
}