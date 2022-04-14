using System.ComponentModel.DataAnnotations;

namespace DesignProject.Models
{
    public class Student : Persons
    {
        [Display(Name ="Course")]
        public string CourseName { get; set; }
        [Display(Name = "Reg Date")]
        public DateTime RegistrationDate { get; set; }
    }
}
