using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using PRN211_Project_Myfap_Src.Models;
using PRN211_Project_Myfap_Src.Services;

namespace PRN211_Project_Myfap_Src.Controllers
{
    public class InstructorController : Controller
    {
        CourseService courseService = new CourseService();
        InstructorService instructorService = new InstructorService();
        CourseScheduleService CourseScheduleService = new CourseScheduleService();
        RollCallBookService rollCallBookService = new RollCallBookService();
        RoomService roomService = new RoomService();
        SubjectService subjectService = new SubjectService();
        TermService termService = new TermService();
        CampusService campusService = new CampusService();
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Calender(int? week, int? cId, int? Iid, int? tId)
        {
            if (cId == null || cId <= 0) cId = 0;
            if (Iid == null || Iid <= 0) Iid = 0;
            if (tId == null || tId <= 0) tId = 1;

            Term term = termService.getById(tId.Value);
            Dictionary<int, List<DateTime>> CalendarMap = CalendarServices.getCalendar(term);

            ViewBag.Weeks = CalendarMap;
            ViewBag.Week = CalendarMap.FirstOrDefault();
            DateTime FromDate = CalendarMap.FirstOrDefault().Value[0];
            DateTime ToDate = CalendarMap.FirstOrDefault().Value[6];
            if (week != null && week > 0)
            {
                var SelectedWeek = CalendarMap.Where(d => d.Key == week).FirstOrDefault();
                ViewBag.Week = SelectedWeek;
                FromDate = SelectedWeek.Value[0];
                ToDate = SelectedWeek.Value[6];
            }
            else week = 1;

            List<Instructor> instructors = instructorService.getList();
            List<CourseSchedule> csList = CourseScheduleService.getListBetweenDate(FromDate, ToDate);
            List<Course> courses = courseService.getListFilter(cId,Iid,tId);
            List<RollCallBook> rollList = rollCallBookService.getList();
            List<Room> roomList = roomService.getList();
            List<Subject> subjectList = subjectService.getList();

            var WeeklySchedule = (
                from i in instructors
                join c in courses on i.InstructorId equals c.InstructorId
                join s in subjectList on c.SubjectId equals s.SubjectId
                join cs in csList on c.CourseId equals cs.CourseId
                join room in roomList on cs.RoomId equals room.RoomId
                join r in rollList on cs.TeachingScheduleId equals r.TeachingScheduleId
                select new
                {
                    i.InstructorId,
                    i.InstructorFirstName,
                    i.InstructorMidName,
                    i.InstructorLastName,
                    c.Term,
                    c.Campus,
                    c.CourseId,
                    c.CourseCode,
                    s.SubjectId,
                    s.SubjectName,
                    room.RoomId,
                    room.RoomCode,
                    cs.Slot,
                    cs.TeachingDate,
                    r.TeachingScheduleId,
                    c.Students
                }).Distinct().ToList();

            ViewData["SelectedWeek"] = week;
            ViewData["SelectedCampus"] = cId;
            ViewData["SelectedTerm"] = tId;
            ViewData["SelectedInstructor"] = Iid;
            ViewBag.terms = termService.getList();
            ViewBag.campus = campusService.getList();
            ViewBag.Ins = instructors;
            ViewBag.slot = 0;
            return View(WeeklySchedule);
        }

        public IActionResult MoveToTakeAttendance(int rId, int sId, int iId, int tId)
        {
            RollCallBook rollCallBook = rollCallBookService.getById(rId);
            Term term = termService.getById(tId);
            Subject subject = subjectService.getById(sId);
            Instructor instructor = instructorService.getById(iId);

            ViewBag.term = term;
            ViewBag.subject = subject;
            ViewBag.instructor = instructor;
            return View("Attendance",rollCallBook);
        }
        {

        }
    }
}
