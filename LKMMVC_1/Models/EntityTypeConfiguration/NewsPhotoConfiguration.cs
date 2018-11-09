using System.Data.Entity.ModelConfiguration;

namespace LKMMVC_1.Models.EntityTypeConfiguration
{
    public class NewsPhotoConfiguration:EntityTypeConfiguration<NewsPhoto>
    {
        public NewsPhotoConfiguration()
        {
            //np=NewsPhotos trumpinys
            HasRequired(np => np.News).WithMany(n => n.NewsPhotos).HasForeignKey(np => np.NewsID);
            ToTable("NewsPhotos");
        }
    }
}