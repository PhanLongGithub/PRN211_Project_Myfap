using Microsoft.EntityFrameworkCore;
using PRN211_Project_Myfap_Src.Models;

namespace PRN211_Project_Myfap_Src.Services
{
    public class RollCallBookService : Service<RollCallBook>
    {
        public override void Create(RollCallBook model)
        {
            throw new NotImplementedException();
        }

        public override bool delete(int id)
        {
            throw new NotImplementedException();
        }

        public override RollCallBook getById(int id)
        {
            using (var context = new APContext())
            {
                return context.RollCallBooks.Include(r => r.TeachingSchedule).Include(r => r.Student).Where(r => r.RollCallBookId == id).FirstOrDefault();
            }
            return null;
        }

        public override List<RollCallBook> getList()
        {
            using (var context = new APContext())
            {
                return context.RollCallBooks.Include(r => r.TeachingSchedule).Include(r => r.Student).ToList();
            }
            return null;
        }

        public override void update(int id)
        {
            throw new NotImplementedException();
        }
    }
}
