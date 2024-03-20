using System.ComponentModel.DataAnnotations;
using Trainning_System.ViewModel;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Trainning_System.Models
{
    public class UniqueAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            string crsName = value?.ToString();
            TrainningSystemContext db = new TrainningSystemContext();
            var crs = db.Course.FirstOrDefault(c => c.Name == crsName);
            
            if (crs == null)
                return ValidationResult.Success;

            updateCourseVM updateVM = validationContext.ObjectInstance as updateCourseVM;

            //no courses with this id in db -> means it's the first time to use this CName
            return (crs.Id == updateVM.Id? 
                        ValidationResult.Success : 
                        new ValidationResult(ErrorMessage = "This name already exists"));
            /*
var existCourses = db.Course.Where(crs => crs.Id == updateVM.Id).ToList();
if (existCourses == null)
    return ValidationResult.Success;
return new ValidationResult(ErrorMessage = "This name already exists");
*/
        }
    }
}