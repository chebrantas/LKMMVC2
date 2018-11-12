
namespace LKMMVC_1.Models
{
    public class MilitaryRank
    {
        public int MilitaryRankID { get; set; }
        public string DateOfReceipt { get; set; }
        public string Rank { get; set; }
        public Biography Biography { get; set; }
        public int BiographyID { get; set; }
    }
}