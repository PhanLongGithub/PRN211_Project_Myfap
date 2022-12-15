using Microsoft.EntityFrameworkCore;
using PRN211_Project_Myfap_Src.Models;

namespace PRN211_Project_Myfap_Src.Services
{
    public class CampusService : Service<Campus>
    {
        public override void Create(Campus model)
        {
            throw new NotImplementedException();
        }

        public override bool delete(int id)
        {
            throw new NotImplementedException();
        }

        public override Campus getById(int id)
        {
            throw new NotImplementedException();
        }

        public override List<Campus> getList()
        {
            using (var context = new APContext())
            {
                return context.Campuses.ToList();
            }
            return null;
        }

        public override void update(int id)
        {
            throw new NotImplementedException();
        }
    }
}
