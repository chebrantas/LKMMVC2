
namespace LKMMVC_1.Models
{
    public class InternationalMissions
    {
        public int InternationalMissionsID { get; set; }
        public string MissionDate { get; set; }
        public string MissionName { get; set; }
        public Biography Biography { get; set; }
        public int BiographyID { get; set; }
    }
}