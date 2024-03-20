using Microsoft.EntityFrameworkCore;
using Trainning_System.Models;
using Trainning_System.ViewModel;

namespace Trainning_System.Repository
{
    public class CourseRepository : ICourseRepository
    {
        TrainningSystemContext db;
        public CourseRepository(TrainningSystemContext db)
        {
            this.db = db;  // inject not create.
            //db = new TrainningSystemContext();
        }

        public List<Course> GetAll(string includes = null)
        {
            return (includes == null ? 
                        db.Course.ToList() : 
                        db.Course.Include(includes).ToList()
                    );
        }

        public Course GetById(int crsId)
        {
            return db.Course.FirstOrDefault(c => c.Id == crsId);
        }
        
        public List<Course> GetDepartmentCoursesByID(int deptID)
        {
            return db.Course.Where(c => c.DepartmentId == deptID).ToList();
        }

        public Course GetByName(string crsName)
        {
            return db.Course.FirstOrDefault(c => c.Name == crsName);
        }

        // List of courses with these data {id, name}
        public List<coursesVM> GetCoursesVM()
        {
            return db.Course.Select(c => new coursesVM { Id = c.Id, Name = c.Name })
                            .ToList<coursesVM>();
        }

        public void Insert(Course course)
        {
            db.Add(course);
        }

        public void Update(int Id, Course course)
        {
            Course oldCourse = GetById(Id);
            oldCourse.Name = course.Name;
            oldCourse.isDeleted = course.isDeleted;
            oldCourse.Degree = course.Degree;
            oldCourse.Min_Degree = course.Min_Degree;
            oldCourse.DepartmentId = course.DepartmentId;
        }

        public void Delete(int Id)
        {
            Course course = GetById(Id);
            course.isDeleted = true;  // soft delete
            //db.Remove(course);
        }

        public int Save()
        {
            return db.SaveChanges();//apply changes and return number of affected rows
        }
    }
}
