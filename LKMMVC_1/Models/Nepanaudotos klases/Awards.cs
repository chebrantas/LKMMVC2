
namespace LKMMVC_1.Models
{
    public class Awards
    {
        public int AwardsID { get; set; }
        public string AwardsDate { get; set; }
        public string AwardsName { get; set; }
        public Biography Biography { get; set; }
        public int BiographyID { get; set; }
    }
}