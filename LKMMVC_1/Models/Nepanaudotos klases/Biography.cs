using System.Collections.Generic;

namespace LKMMVC_1.Models
{
    public class Biography
    {
        public int BiographyID { get; set; }
        public string Name { get; set; }
        public string BornDate { get; set; }
        public string BornPlace { get; set; }
        public string Family { get; set; }
        public string Language { get; set; }
        public List<Education> Educations { get; set; }
        public List<MilitaryRank> MilitaryRanks { get; set; }
        public List<ProfessionalExperience> ProfessionalExperiences { get; set; }
        public List<InternationalMissions> InternationalMissions { get; set; }
        public List<Awards> Awards { get; set; }

    }
}