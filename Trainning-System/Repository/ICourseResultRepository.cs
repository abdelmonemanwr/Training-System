using Trainning_System.Models;

namespace Trainning_System.Repository
{
    public interface ICourseResultRepository
    {
        IEnumerable<crsResult> GetCourseResults(int crsId);
        
        void Insert(crsResult crsResult);

        void Update(int Id, crsResult crsResult);

        void Delete(int Id);

        int Save();
    }
}