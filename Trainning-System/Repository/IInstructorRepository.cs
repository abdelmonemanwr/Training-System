using Trainning_System.Models;
using Trainning_System.ViewModel;

namespace Trainning_System.Repository
{
    public interface IInstructorRepository
    {
        List<Instructor> GetAll(string departments = null, string courses = null);

        Instructor GetById(int insId, string departments = null, string courses = null);

        Instructor GetByName(string insName);

        List<instructorVM> GetInstructorsVM();

        IEnumerable<Instructor> GetCourseInstructors(int crsId);
        
        void Insert(Instructor instructor);

        void Update(int Id, Instructor instructor);

        void Delete(int Id);

        int Save();
    }
}