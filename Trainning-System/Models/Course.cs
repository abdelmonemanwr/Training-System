using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Trainning_System.Models
{
    public class Course
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }

        [DefaultValue(false)]
        public bool? isDeleted { get; set; }

        public int? Degree { get; set; }
        public int? Min_Degree { get; set; }

        [ForeignKey("Department")]
        public int DepartmentId { get; set; }

        // Navigation Properties
        public virtual Department Department { get; set; }
        public virtual ICollection<Instructor> Instructor { get; set; } = new List<Instructor>();
        public virtual ICollection<crsResult> crsResult { get; set; } = new List<crsResult>();
    }
}