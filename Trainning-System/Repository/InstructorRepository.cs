using Microsoft.EntityFrameworkCore;
using Trainning_System.Models;
using Trainning_System.ViewModel;

namespace Trainning_System.Repository
{
    public class InstructorRepository: IInstructorRepository
    {
        TrainningSystemContext db;
        public InstructorRepository(TrainningSystemContext db)
        {
            this.db = db;  // inject not create.
            //db = new TrainningSystemContext();
        }

        public List<Instructor> GetAll(string departments = null, string courses = null)
        {
            if (departments == null && courses == null)
                return db.Instructor.ToList();
            
            else if (departments != null)
                return db.Instructor.Include(departments).ToList();
            
            else if (courses != null)
                return db.Instructor.Include(courses).ToList();

            return db.Instructor.Include(departments).Include(courses).ToList();
        }

        public Instructor GetById(int insId, string departments = null, string courses = null)
        {
            if (departments == null && courses == null)
                return db.Instructor.FirstOrDefault(ins => ins.Id == insId);

            else if (departments != null && courses == null)
                return db.Instructor.Include(departments)
                                    .FirstOrDefault(ins => ins.Id == insId);

            else if (courses != null && departments == null)
                return db.Instructor.Include(courses)
                                    .FirstOrDefault(ins => ins.Id == insId);

            return db.Instructor.Include(departments)
                                .Include(courses)
                                .FirstOrDefault(ins => ins.Id == insId);
        }

        public Instructor GetByName(string insName)
        {
            return db.Instructor.FirstOrDefault(c => c.Name == insName);
        }

        public List<instructorVM> GetInstructorsVM()
        {
            return db.Instructor.Where(i => i.Course == null)
                     .Select(inst => new instructorVM { sid = inst.Id, Name = inst.Name })
                     .ToList();
        }

        public IEnumerable<Instructor> GetCourseInstructors(int crsId)
        {
            return db.Instructor.Where(crs => crs.CourseId == crsId);
        }

        public void Insert(Instructor instructor)
        {
            db.Add(instructor);
        }

        public void Update(int Id, Instructor instructor)
        {
            Instructor oldInstructor = GetById(Id);
            oldInstructor.Name = instructor.Name;
            oldInstructor.salary = instructor.salary;
            oldInstructor.Address = instructor.Address;
            oldInstructor.Image = instructor.Image;
            oldInstructor.DepartmentId = instructor.DepartmentId;
            oldInstructor.CourseId = instructor.CourseId;
        }

        public void Delete(int Id)
        {
            Instructor instructor = GetById(Id);
            db.Remove(instructor);
        }

        public int Save()
        {   //apply changes and return number of affected rows
            return db.SaveChanges();
        }
    }
}
