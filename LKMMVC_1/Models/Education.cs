
namespace LKMMVC_1.Models
{
    public class Education
    {
        public int EducationID { get; set; }
        //issilavinimo gavimo data
        public string DateOfReceipt { get; set; }
        //issilavinimo pavadinimas
        public string EducationName { get; set; }
        public Biography Biography { get; set; }
        public int BiographyID { get; set; }
    }
}