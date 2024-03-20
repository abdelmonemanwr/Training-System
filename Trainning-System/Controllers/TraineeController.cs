using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Linq;
using Trainning_System.Models;
using Trainning_System.ViewModel;

namespace Trainning_System.Controllers
{
    public class TraineeController : Controller
    {
        TrainningSystemContext db = new TrainningSystemContext();

        // trainee/showResult/id/crsId
        public IActionResult showResult(int crsId, int id)
        {
            TraineeName_CourseName_CourseResult_Data_ViewModel vm = new 
                TraineeName_CourseName_CourseResult_Data_ViewModel();
            try{
                vm.traineeName = db.Trainee.FirstOrDefault(t => t.Id == id).Name;
                vm.courseDegree = db.CrsResult.FirstOrDefault(r => r.CourseId == crsId && r.TraineeId == id).Degree;
                var crsData = db.Course.FirstOrDefault(c => c.Id == crsId);

				vm.courseName = crsData.Name;
                int? minDegree = crsData.Min_Degree;
                vm.color = (vm.courseDegree >= minDegree) ? "green" : "red";

                ViewBag.theme = HttpContext.Session.GetString("themeColor"); // ??
                //Debug.WriteLine(ViewBag.theme);
                return View("showResult", vm);
            } 
            catch(Exception ex)
            {
                Debug.WriteLine("{error} : "+ex.Message);
				return View("Error");
            }
        }

        // http://localhost:5252/trainee/SetThemeColor?selectedColor=black
        public IActionResult SetThemeColor(string selectedColor)
		{
			// cookies
			//TempData["themeColor"] = selectedColor;
			HttpContext.Session.SetString("themeColor", selectedColor);
			return View("sessionAdded", new {themeColor=selectedColor});
		}

        public IActionResult ShowCourseResults(int id)
        {
            List<ShowCourseResults> vm = new List<ShowCourseResults>();

            var ret = db.CrsResult.Where(c => c.CourseId == id)
            .Include(c => c.Course)
            .Include(t => t.Trainee)
            .Select(c => new {
                    TraineeName = c.Trainee.Name,
                    TraineeDegree = (int)c.Degree,
                    CourseMinDegree = (int)c.Course.Min_Degree,
                    Color = ((int)c.Degree >= c.Course.Min_Degree) ? "green" : "red",
                }).
            ToList();

            foreach (var item in ret)
            {
                vm.Add(new ViewModel.ShowCourseResults
                {
                    name = item.TraineeName,
                    degree = item.TraineeDegree,
                    color = item.Color
                });
            }
            ViewBag.courseName = db.Course.
                Where(c => c.Id == id).
                Select(c => c.Name).FirstOrDefault();
            return View("ShowCourseResults", vm);
        }

        public IActionResult ShowTraineeResults(int id)
        {
            List<ShowTraineeResults> vm = new List<ShowTraineeResults>();

            var ret = db.CrsResult.Where(c => c.TraineeId == id)
            .Include(c => c.Course)
            .Select(c => new {
                CourseName = c.Course.Name,
                TraineeDegree = (int)c.Degree,
                CourseMinDegree = (int)c.Course.Min_Degree,
                Color = ((int)c.Degree >= c.Course.Min_Degree) ? "green" : "red",
            }).
            ToList();

            foreach (var item in ret)
            {
                vm.Add(new ViewModel.ShowTraineeResults
                {
                    course = item.CourseName,
                    degree = item.TraineeDegree,
                    color = item.Color.ToString()
                });
            }
            ViewBag.traineeName = db.Trainee.Where(t => t.Id == id).Select(c => c.Name).FirstOrDefault();
            return View("ShowTraineeResults", vm);
        }
    }
}
