using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Trainning_System.Models
{
    public class crsResult
    {
        [Key]
        public int Id { get; set; }
        public int? Degree { get; set; }

        [ForeignKey("Course")]
        public int? CourseId { get; set; }

        [ForeignKey("Trainee")]
        public int TraineeId { get; set; }
        [DeleteBehavior(DeleteBehavior.NoAction)]
        public virtual Course Course { get; set; }
        [DeleteBehavior(DeleteBehavior.NoAction)]
        public virtual Trainee Trainee { get; set; }
    }
}
