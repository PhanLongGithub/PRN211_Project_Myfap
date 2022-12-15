using Microsoft.EntityFrameworkCore;
using PRN211_Project_Myfap_Src.Models;

namespace PRN211_Project_Myfap_Src.Services
{
    public class CourseScheduleService : Service<CourseSchedule>
    {
        public override void Create(CourseSchedule model)
        {
            throw new NotImplementedException();
        }

        public override bool delete(int id)
        {
            throw new NotImplementedException();
        }

        public override CourseSchedule getById(int id)
        {
            throw new NotImplementedException();
        }

        public override List<CourseSchedule> getList()
        {
            using (var context = new APContext())
            {
                return context.CourseSchedules.Include(c => c.Course).Include(c => c.Room).Include(c => c.RollCallBooks).ToList();
            }
            return null;
        }

        public override void update(int id)
        {
            throw new NotImplementedException();
        }

        public List<CourseSchedule> getListBetweenDate(DateTime from, DateTime to)
        {
            using (var context = new APContext())
            {
                return context.CourseSchedules
                    .Include(c => c.Course)
                    .Include(c => c.Room)
                    .Include(c => c.RollCallBooks)
                    .Where(c => c.TeachingDate >= from && c.TeachingDate <= to)
                    .ToList();
            }
            return null;
        }
    }
}
