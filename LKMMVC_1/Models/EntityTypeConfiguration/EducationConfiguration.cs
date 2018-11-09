using System.Data.Entity.ModelConfiguration;

namespace LKMMVC_1.Models.EntityTypeConfiguration
{
    public class EducationConfiguration:EntityTypeConfiguration<Education>
    {
        public EducationConfiguration()
        {
            HasRequired(e => e.Biography).WithMany(b => b.Educations).HasForeignKey(e => e.BiographyID);
             
        }
    }
}