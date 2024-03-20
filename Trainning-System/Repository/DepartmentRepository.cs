using System.Linq;
using Trainning_System.Models;
using Trainning_System.ViewModel;

namespace Trainning_System.Repository
{
    public class DepartmentRepository : IDepartmentRepository
    {
        TrainningSystemContext db;
        public DepartmentRepository(TrainningSystemContext db)
        {
            this.db = db;  // inject not create.
            //db = new TrainningSystemContext();
        }

        public Department GetById(int deptId)
        {
            return db.Department.FirstOrDefault(d => d.Id == deptId);
        }

        public List<departmentVM> GetDepartmentsVM()
        {
            return db.Department.Select(dept => new departmentVM { did = dept.Id, Name = dept.Name })
                                .ToList();
        }

        public List<deptsVM> GetInstructorsDepartments()
        {
            return db.Department.Select(dept => new deptsVM { Id = dept.Id, Name = dept.Name })
                                .ToList();
        }

        public void Insert(Department department)
        {
            db.Add(department);
        }

        public void Delete(int Id)
        {
            Department department = GetById(Id);
            db.Remove(department);
        }
        
        public void Update(int Id, Department department)
        {
            Department oldDepartment = GetById(Id);
            oldDepartment.Name = department.Name;
            oldDepartment.Manager = department.Manager;
        }

        public int Save()
        {
            return db.SaveChanges();
        }
    }
}
