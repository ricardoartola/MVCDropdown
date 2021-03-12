using MVCDropdown.Infrastructure;
using MVCDropdown.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCDropdown.Controllers
{
    public class HomeController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpGet]
        public JsonResult GetDepartments()
        {
            var departments = db.Departments.ToList();
            departments.Insert(0, new Department() { DepartmentId = 0, Name = "--All Departments--" });
            var result = (from r in departments
                          select new
                          {
                              id = r.DepartmentId,
                              name = r.Name
                          }).ToList();

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetProgramsByDepartmentId(int id)
        {
            var programs = GetProgramsByDepId(id);
            var result = (from r in programs
                          select new
                          {
                              id = r.Id,
                              name = r.Name
                          }).ToList();

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public List<Program> GetProgramsByDepId(int id)
        {
            List<Program> programs = new List<Program>();
            if (id > 0)
                programs = db.Programs.Where(p => p.DepartmentId == id).ToList();
            else
                programs.Insert(0, new Program { Id = 0, Name = "--Select a program--" });

            return programs;
        }

    }
}