using HarshaApi1.CustomValidations;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HarshaApi1.Models
{
    public class Employee
    {
        public int Id { get; set; }
        [BindNever]
        public string? Name { get; set; }
        public string? Designation { get; set; }
        [NotMapped]
        [Required(ErrorMessage="{0} is required")]
        [MinmumYearValidations]
        public DateTime? JoingDate { get; set; }=null;
    }
}
