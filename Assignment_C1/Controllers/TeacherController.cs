using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Assignment_C1.Models;

namespace Assignment_C1.Controllers
{
    public class TeacherController : Controller
    {
        // GET: Teacher
        [HttpGet]
        public ActionResult List()
        {
            TeacherDataController Controller = new TeacherDataController();
            IEnumerable<Teacher> Teacher = Controller.ShowTeachers();
            return View(Teacher);
        }


        [HttpGet]
        // GET: Teacher/Show/{id}
        [Route("Teacher/Show/{id}")]
        public ActionResult Show(int id)
        {
            TeacherDataController controller = new TeacherDataController();
            Teacher NewTeacher = controller.FindTeacher(id);
            return View(NewTeacher);
        }
    }
}