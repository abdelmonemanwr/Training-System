using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Trainning_System.Models;

namespace Trainning_System.ViewModel
{
    public class updateCourseVM
    {
        [Key] [Required] 
        [DisplayName("Course ID")]
        public int Id { get; set; }

        [DisplayName("Course Name")]
        [Unique(ErrorMessage = "Please choose a unique course name")]
        public string Name { get; set; }

        [DisplayName("Course Degree")]
        [Range(55, 100, ErrorMessage = "Course Degree must be between [55 : 100].")]
        public int? Degree { get; set; }

        [Required]
        [DisplayName("Course Min Degree")]
        [Remote("CheckMinDegree", "Course", AdditionalFields = "Degree",
                ErrorMessage = "Course Minimum Degree must be a value between 0 and your entered Degree.")]
        public int? Min_Degree { get; set; }

        [DisplayName("Department Name")]
        [RegularExpression("^[1-9]{1,}[0-9]{0,}$", ErrorMessage = "Please choose department")]
        public int did { get; set; }

        public List<departmentVM>? departments { get; set; }
    }
}
