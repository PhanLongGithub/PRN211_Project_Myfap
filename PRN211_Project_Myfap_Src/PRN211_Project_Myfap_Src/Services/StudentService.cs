using Microsoft.EntityFrameworkCore;
using PRN211_Project_Myfap_Src.Models;

namespace PRN211_Project_Myfap_Src.Services
{
    public class StudentService : Service<Student>
    {
        public override void Create(Student model)
        {
            throw new NotImplementedException();
        }

        public override bool delete(int id)
        {
            throw new NotImplementedException();
        }

        public override Student getById(int id)
        {
            throw new NotImplementedException();
        }

        public override List<Student> getList()
        {
            using (var context = new APContext())
            {
                return context.Students.Include(s => s.RollCallBooks).Include(s => s.Courses).ToList();
            }
            return null;
        }

        public override void update(int id)
        {
            throw new NotImplementedException();
        }
    }
}
