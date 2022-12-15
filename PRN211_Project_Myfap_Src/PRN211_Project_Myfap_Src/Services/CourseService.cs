using Microsoft.EntityFrameworkCore;
using PRN211_Project_Myfap_Src.Models;

namespace PRN211_Project_Myfap_Src.Services
{
    public class CourseService : Service<Course>
    {
        public override void Create(Course model)
        {
            throw new NotImplementedException();
        }

        public override bool delete(int id)
        {
            throw new NotImplementedException();
        }

        public override Course getById(int id)
        {
            throw new NotImplementedException();
        }

        public override List<Course> getList()
        {
            using (var context = new APContext())
            {
                return context.Courses.
                    Include(c => c.Campus).
                    Include(c => c.Instructor).
                    Include(c => c.Subject).
                    Include(c => c.Term).
                    Include(c => c.Students).
                    Include(c => c.CourseSchedules).ToList();
            }
            return null;
        }

        public override void update(int id)
        {
            throw new NotImplementedException();
        }

        public List<Course> getListFilter(int? cId, int? Iid, int? tId)
        {
            if (cId != null && Iid != null && tId != null)
            {
                using (var context = new APContext())
                {
                    return context.Courses.
                        Include(c => c.Campus).
                        Include(c => c.Instructor).
                        Include(c => c.Subject).
                        Include(c => c.Term).
                        Include(c => c.Students).
                        Include(c => c.CourseSchedules)
                        .Where(c => c.CampusId == cId)
                        .Where(c => c.TermId == tId)
                        .Where(c => c.InstructorId == Iid)
                        .ToList();
                }
            }
            return null;
        }
    }
}
