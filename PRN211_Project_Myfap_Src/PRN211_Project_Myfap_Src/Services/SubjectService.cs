using Microsoft.EntityFrameworkCore;
using PRN211_Project_Myfap_Src.Models;

namespace PRN211_Project_Myfap_Src.Services
{
    public class SubjectService : Service<Subject>
    {
        public override void Create(Subject model)
        {
            throw new NotImplementedException();
        }

        public override bool delete(int id)
        {
            throw new NotImplementedException();
        }

        public override Subject getById(int id)
        {
            using (var context = new APContext())
            {
                return context.Subjects
                    .Include(s => s.Department)
                    .Include(x => x.Courses)
                    .Where(s => s.SubjectId == id)
                    .FirstOrDefault();
            }
            return null;
        }

        public override List<Subject> getList()
        {
            using (var context = new APContext())
            {
                return context.Subjects
                    .Include(s => s.Department)
                    .Include(x => x.Courses)
                    .ToList();
            }
            return null;
        }

        public override void update(int id)
        {
            throw new NotImplementedException();
        }
    }
}
