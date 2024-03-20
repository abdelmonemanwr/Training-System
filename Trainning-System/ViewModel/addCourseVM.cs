using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages.Infrastructure;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Trainning_System.Models;

namespace Trainning_System.ViewModel
{
    public class addCourseVM
    {
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

        [DisplayName("Instructor Name")]
        [RegularExpression("^[1-9]{1,}[0-9]{0,}$", ErrorMessage = "Please choose instructor")]
        public int sid { get; set; }

        public List<departmentVM>? departments { get; set; }
        public List<instructorVM>? instructors { get; set; }
    }

    public class departmentVM
    {
        public int did { get; set; }
        public string Name { get; set; }
    }

    public class instructorVM
    {
        public int sid { get; set; }
        public string Name { get; set; }
    }
}
