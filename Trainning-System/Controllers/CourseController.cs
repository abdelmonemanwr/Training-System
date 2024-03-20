using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;
using Trainning_System.Models;
using Trainning_System.Repository;
using Trainning_System.ViewModel;

namespace Trainning_System.Controllers
{
    public class CourseController : Controller
    {
        // DIP: Dependancy In Principle
        ICourseResultRepository courseResultRepository;
        IDepartmentRepository departmentRepository;
        IInstructorRepository instructorRepository;
        ICourseRepository courseRepository;

        // DI : Dependancy Injection --> sologan: don't create but ask (inject)
        public CourseController(ICourseRepository courseRepository, ICourseResultRepository courseResultRepository, IInstructorRepository instructorRepository, IDepartmentRepository departmentRepository)
        {
            // don't create

            //courseResultRepository = new CourseResultRepository();
            //departmentRepository = new DepartmentRepository();
            //instructorRepository = new InstructorRepository();
            //courseRepository = new CourseRepository();

            // ask (inject)

            this.courseResultRepository = courseResultRepository;
            this.departmentRepository = departmentRepository;
            this.instructorRepository = instructorRepository;
            this.courseRepository = courseRepository;
        }

        #region Helper methods
        addCourseVM vm;
        private void fetchDataIntoVM()
        {
            vm = new addCourseVM();
            vm.departments = departmentRepository.GetDepartmentsVM();
            vm.instructors = instructorRepository.GetInstructorsVM();
        }

        // now we use if(ModelState.IsValid == true) 
        private bool checkCourseData(addCourseVM vm)
        {
            return (vm.Name != null && vm.Degree > 0 &&
                     vm.Min_Degree > 0 && vm.Min_Degree <= vm.Degree &&
                     vm.did != 0 && vm.sid != 0
                    );
        }
        #endregion

        #region Base Page
        public IActionResult Index()
        {
            var courses = courseRepository.GetAll("Department");
            return View("Index", courses);
        }
        #endregion

        #region Add Course
        [HttpGet]
        public IActionResult addCourse()
        {
            fetchDataIntoVM();
            return View("addCourse", vm);
        }

        [HttpPost]
        public IActionResult addCourse(addCourseVM crsvm)
        {
            if(ModelState.IsValid==true)
            {
                try
                {
                    Course course = new Course
                    {
                        Name = crsvm.Name,
                        Degree = crsvm.Degree,
                        Min_Degree = crsvm.Min_Degree,
                        DepartmentId = crsvm.did
                    };
                    
                    courseRepository.Insert(course);
                    courseRepository.Save();

                    var instructor = instructorRepository.GetById(crsvm.sid);

                    var ourCourse = courseRepository.GetByName(crsvm.Name);
                    
                    if (instructor != null && ourCourse != null)
                    {
                        instructor.CourseId = ourCourse.Id;
                        instructor.Course = ourCourse;
                        instructorRepository.Save();
                        return RedirectToAction("Index");
                    } 
                    else
                    {
                        fetchDataIntoVM();
                        return View("addCourse", crsvm);
                    }

                }
                catch (Exception ex)
                {
                    fetchDataIntoVM();
                    return View("addCourse", crsvm);
                }
            }
            else
            {
                fetchDataIntoVM();
                return View("addCourse", vm);
            }
        }
        #endregion

        #region Update Course
        // [Remote]
        public IActionResult CheckMinDegree(int Min_Degree, int Degree){
            return (Min_Degree <= Degree && Min_Degree > 0 ? Json(true) : Json(false));
        }

        [HttpGet]
        public IActionResult UpdateCourse(int id)
        {
            var crs = courseRepository.GetById(id);
            
            updateCourseVM update = new updateCourseVM();
            
            update.Id = crs.Id;
            update.Name = crs.Name;
            update.Degree = crs.Degree;
            update.Min_Degree = crs.Min_Degree;

            update.did = crs.DepartmentId;
            update.departments = departmentRepository.GetDepartmentsVM();

            return View("UpdateCourse", update);
        }

        [HttpPost]
        public IActionResult UpdateCourse(updateCourseVM courseModel)
        {
            int crsId = 0;
            int.TryParse(HttpContext.Request.RouteValues["id"].ToString(), out crsId);
            courseModel.Id = crsId;
            if (ModelState.IsValid == false)
            {
                courseModel.departments = departmentRepository.GetDepartmentsVM();

                return View("UpdateCourse", courseModel);
            }

            Course crs = courseRepository.GetById(crsId);

            crs.Name = courseModel.Name;
            crs.Degree = courseModel.Degree;
            crs.DepartmentId = courseModel.did;
            crs.Min_Degree = courseModel.Min_Degree;
            
            courseRepository.Save();
            return RedirectToAction("Index");
        }
        #endregion

        #region Delete Course
        public IActionResult DeleteCourse(int id)
        {
            #region soft delete
            courseRepository.Delete(id);
            courseRepository.Save();
            return RedirectToAction("Index");
            #endregion

            //Note: I update delete:CourseRepository to soft delete, not remove from db
            //if u want to use traditional way: uncomment db.Remove() from course repo.
            #region traditional way: deleting from database
            /*
            Course course = courseRepository.GetById(id); 
            try
            {   
                courseRepository.Delete(id);

                var existInstructors = instructorRepository.GetCourseInstructors(course.Id);

                foreach(var ins in existInstructors)
                    ins.CourseId = null;
                // instructorRepository.Save();  // no need for it, i'll save using course repository

                var existCoursesResult = courseResultRepository.GetCourseResults(course.Id);
                foreach(var crs in existCoursesResult)
                    crs.CourseId = null;
                // courseResultRepository.Save();  // no need for it, i'll save using course repository

                courseRepository.Save();
            }
            catch (Exception ex)
            {
                return NotFound();
            }
            return RedirectToAction("Index");
            */
            #endregion
        }
        #endregion
    }
}