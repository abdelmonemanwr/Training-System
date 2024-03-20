using Trainning_System.Models;
using Trainning_System.ViewModel;

namespace Trainning_System.Repository
{
    public interface ICourseRepository
    {
        List<Course> GetAll(string includes = null);
        
        Course GetById(int crsId);

        Course GetByName(string crsName);

        List<Course> GetDepartmentCoursesByID(int deptID);

        List<coursesVM> GetCoursesVM();

        void Insert(Course course);

        void Update(int Id, Course course);

        void Delete(int Id);

        int Save();
    }
}
