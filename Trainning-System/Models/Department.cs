using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace Trainning_System.Models
{
    public class Department
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Manager { get; set; }
        public virtual ICollection<Instructor> Instructor { get; set; } = new List<Instructor>();
        public virtual ICollection<Trainee> Trainee { get; set; } = new List<Trainee>();
        public virtual ICollection<Course> Course { get; set; } = new List<Course>();
    }
}
