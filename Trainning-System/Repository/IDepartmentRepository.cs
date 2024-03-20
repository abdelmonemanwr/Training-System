using Trainning_System.Models;
using Trainning_System.ViewModel;

namespace Trainning_System.Repository
{
    public interface IDepartmentRepository
    {
        Department GetById(int deptId);

        List<departmentVM> GetDepartmentsVM();

        List<deptsVM> GetInstructorsDepartments();

        void Insert(Department department);

        void Update(int Id, Department department);

        void Delete(int Id);

        int Save();
    }
}