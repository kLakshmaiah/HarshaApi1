using System.ComponentModel.DataAnnotations;

namespace HarshaApi1.Models
{
    public class Student
    {
        //[Required(ErrorMessage = "{0} is required")]
        //[Range(33, 333, ErrorMessage = "{0} value between {1} and {2}")]
        public int Id { get; set; } 
        public string? Name { get; set; }
        public string? RollNo { get; set; }
        public string? Class { get; set; }
        public string? Section { get; set; }
        //[StringLength(10,MinimumLength =10,ErrorMessage = "{0} having {1} digits onlys")]
        //[RegularExpression(@"^[0-9]*$",ErrorMessage = "{0} should be number")]
        public string? MobileNumber { get; set; }
    }
}
