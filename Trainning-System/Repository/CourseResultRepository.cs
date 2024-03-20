using Trainning_System.Models;

namespace Trainning_System.Repository
{
    public class CourseResultRepository : ICourseResultRepository
    {
        TrainningSystemContext db;
        public CourseResultRepository(TrainningSystemContext db)
        {
            this.db = db;  // inject not create.
            //db = new TrainningSystemContext();
        }
        public IEnumerable<crsResult> GetCourseResults(int crsId)
        {
            return db.CrsResult.Where(crs => crs.CourseId == crsId);
        }

        public crsResult GetById(int id)
        {
            return db.CrsResult.FirstOrDefault(c => c.Id == id);
        }

        public void Insert(crsResult crsResult)
        {
            db.Add(crsResult);
        }

        public void Update(int Id, crsResult crsResult)
        {
            crsResult oldCrsResult = GetById(Id);
            oldCrsResult.Degree = crsResult.Degree;
            oldCrsResult.CourseId = crsResult.CourseId;
            oldCrsResult.TraineeId = crsResult.TraineeId;
        }

        public void Delete(int Id)
        {
            crsResult crsResult = GetById(Id);
            db.Remove(crsResult);
        }

        public int Save()
        {
            return db.SaveChanges();
        }
    }
}
