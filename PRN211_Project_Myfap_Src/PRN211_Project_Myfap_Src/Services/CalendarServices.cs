using PRN211_Project_Myfap_Src.Models;

namespace PRN211_Project_Myfap_Src.Services
{
    public class CalendarServices
    {

        public static Dictionary<int, List<DateTime>> getCalendar(Term term)
        {
            int count = 0;
            int key = 0;
            List<DateTime> weeks = new List<DateTime>();
            Dictionary<int, List<DateTime>> CalendarMap = new Dictionary<int, List<DateTime>>();
            DateTime to = term.ToDate.Value;
            DateTime start = term.FromDate.Value;
            for (var i = start; i < to; i = i.AddDays(1))
            {
                while(i.DayOfWeek != DayOfWeek.Monday && count == 0)
                {
                    i = i.AddDays(-1);
                }
                weeks.Add(i);
                count++;
                if(count == 7)
                {
                    key++;
                    CalendarMap.Add(key, weeks);
                    weeks = new List<DateTime>();
                    count = 0;
                }
            }
            return CalendarMap;
        }
    }
}
