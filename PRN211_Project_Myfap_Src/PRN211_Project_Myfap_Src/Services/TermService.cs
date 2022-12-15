using Microsoft.EntityFrameworkCore;
using PRN211_Project_Myfap_Src.Models;

namespace PRN211_Project_Myfap_Src.Services
{
    public class TermService : Service<Term>
    {
        public override void Create(Term model)
        {
            throw new NotImplementedException();
        }

        public override bool delete(int id)
        {
            throw new NotImplementedException();
        }

        public override Term getById(int id)
        {
            using (var context = new APContext())
            {
                return context.Terms.Where(t => t.TermId == id).FirstOrDefault();
            }
            return null;
        }

        public override List<Term> getList()
        {
            using (var context = new APContext())
            {
                return context.Terms.ToList();
            }
            return null;
        }

        public override void update(int id)
        {
            throw new NotImplementedException();
        }
    }
}
