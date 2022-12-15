using Microsoft.EntityFrameworkCore;
using PRN211_Project_Myfap_Src.Models;

namespace PRN211_Project_Myfap_Src.Services
{
    public class InstructorService : Service<Instructor>
    {
        public override void Create(Instructor model)
        {
            throw new NotImplementedException();
        }

        public override bool delete(int id)
        {
            throw new NotImplementedException();
        }

        public override Instructor getById(int id)
        {
            using (var context = new APContext())
            {
                return context.Instructors.Include(i => i.Department).Include(i => i.Courses).Where(i => i.InstructorId == id).FirstOrDefault();
            }
            return null;
        }

        public override List<Instructor> getList()
        {
            using (var context = new APContext())
            {
                return context.Instructors.Include(i => i.Department).Include(i => i.Courses).ToList();
            }
            return null;
        }

        public override void update(int id)
        {
            throw new NotImplementedException();
        }
    }
}
