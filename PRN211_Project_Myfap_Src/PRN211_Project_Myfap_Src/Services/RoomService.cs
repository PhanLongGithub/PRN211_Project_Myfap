using Microsoft.EntityFrameworkCore;
using PRN211_Project_Myfap_Src.Models;

namespace PRN211_Project_Myfap_Src.Services
{
    public class RoomService : Service<Room>
    {
        public override void Create(Room model)
        {
            throw new NotImplementedException();
        }

        public override bool delete(int id)
        {
            throw new NotImplementedException();
        }

        public override Room getById(int id)
        {
            throw new NotImplementedException();
        }

        public override List<Room> getList()
        {
            using (var context = new APContext())
            {
                return context.Rooms.Include(r => r.Campus).Include(r => r.CourseSchedules).ToList();
            }
            return null;
        }

        public override void update(int id)
        {
            throw new NotImplementedException();
        }
    }
}
