using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;

namespace Trainning_System.Models
{
    public class Instructor
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Image { get; set; }
        public int? salary { get; set; }
        public string? Address { get; set; }

        [ForeignKey("Department")]
        public int DepartmentId { get; set; }
        [DeleteBehavior(DeleteBehavior.NoAction)]
        public virtual Department Department { get; set; }

        [ForeignKey("Course")]
        public int? CourseId { get; set; }
        [DeleteBehavior(DeleteBehavior.NoAction)]
        public virtual Course Course { get; set; }
    }
}
