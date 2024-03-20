using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using Trainning_System.Models;

namespace Trainning_System.ViewModel
{
    public class InstructorData_ListDepartments_ListCourses
    {
        public string? Name { get; set; }
        public string? Image { get; set; }
        public int? salary { get; set; }
        public string? Address { get; set; }
        public int? courseId { get; set; }
        public int? deptId { get; set; }
        public virtual List<coursesVM> Course { get; set; }
        public virtual List<deptsVM> Department { get; set; }
    }

    public class deptsVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class coursesVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
