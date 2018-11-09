
namespace LKMMVC_1.Models
{
    public class ProfessionalExperience
    {
        public int ProfessionalExperienceID { get; set; }
        public string DateOfReceipt { get; set; }
        public string ExperienceName { get; set; }
        public Biography Biography { get; set; }
        public int BiographyID { get; set; }
    }
}