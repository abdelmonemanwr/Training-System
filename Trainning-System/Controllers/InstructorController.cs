using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Trainning_System.Models;
using Trainning_System.Repository;
using Trainning_System.ViewModel;

namespace Trainning_System.Controllers
{
    public class InstructorController : Controller
    {
        //TrainningSystemContext db = new TrainningSystemContext();

        IInstructorRepository instructorRepository;
        IDepartmentRepository departmentRepository;
        ICourseRepository courseRepository;

        public InstructorController(IInstructorRepository instructorRepository, ICourseRepository courseRepository, IDepartmentRepository departmentRepository)
        {
            this.courseRepository = courseRepository;
            this.instructorRepository = instructorRepository;
            this.departmentRepository = departmentRepository;
            
            //courseRepository = new CourseRepository();
            //instructorRepository = new InstructorRepository();
            //departmentRepository = new DepartmentRepository();
        }

        #region Helper Functions

        #region validate form data
        private bool checkInstructorData(Instructor instructor)
        {
            return ( instructor.Name != null && instructor.salary != null && 
                     instructor.Image != null && instructor.Address != null && 
                     instructor.CourseId != 0 && instructor.DepartmentId != 0
                   );
        }
        #endregion

        #region Mapping Instructor Data Into View Model
        private void mapData(InstructorData_ListDepartments_ListCourses vm, Instructor instructor)
        {
            vm.Name = instructor.Name;
            vm.Image = instructor.Image;
            vm.salary = instructor.salary;
            vm.Address = instructor.Address;
            vm.courseId = instructor.CourseId;
            vm.deptId = instructor.DepartmentId;
        }
        #endregion

        #region Fill vm with deptID, deptName, crsId and crsName
        InstructorData_ListDepartments_ListCourses vm;
        public void fetchDataIntoVM()
        {
            vm = new InstructorData_ListDepartments_ListCourses();

            // get specifc properties from courses
            vm.Course = courseRepository.GetCoursesVM();

            // get specifc properties from departments
            vm.Department = departmentRepository.GetInstructorsDepartments();
        }
        #endregion

        #endregion

        #region To get all instructors => instructor/index
        public IActionResult Index()
        {
            //db.Instructor.Include(d => d.Department).Include(d => d.Course).ToList();
            var instructors = instructorRepository.GetAll("Department", "Course");
            return View("Index", instructors);
        }
        #endregion

        #region To get 1 instructor => instructor/getone 
        public IActionResult getOne(int id)
        {
            // db.Instructor.Include(d => d.Department).Include(d => d.Course).FirstOrDefault(ins => ins.Id == id);
            var instructor = instructorRepository.GetById(id, "Department", "Course");
            return (instructor != null ? View("getOne", instructor) : NotFound());
        }
        #endregion

        #region To add new instructor form input
        // => instructor/addInstructor
        public IActionResult addInstructor()
        {
            try
            {
                fetchDataIntoVM();
                return View("addInstructor", vm);
            }
            catch (Exception ex)
            {
                return NotFound();
            }
        }
        #endregion

        #region To save instructor's data form input 
        // => instructor/saveInstructorData?instructor=instructor
        [HttpPost]
        public IActionResult saveInstructorData(Instructor instructor)
        {
            if (checkInstructorData(instructor))
            {
                try
                {
                    instructorRepository.Insert(instructor);
                    instructorRepository.Save();
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    ViewData["missed"] = "true";
                }
            }
            //ViewData["missed"] = "true";
            fetchDataIntoVM();
            mapData(vm, instructor);
            return View("addInstructor", vm);
        }
        #endregion

        #region ajax get specific departments' courses
        public IActionResult getDepartmentCourses(int did)
        {
            // db.Course.Where(crs => crs.DepartmentId == did).ToList();
            List<Course> courses = courseRepository.GetDepartmentCoursesByID(did);
            return Json(courses);
        }
        #endregion
    }
}