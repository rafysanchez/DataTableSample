using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DataTableSample.Controllers
{
    public class DTSampleController : Controller
    {
        // GET: DTSample
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Students()
        {
            Models.DataTable dataTable = new Models.DataTable();
            dataTable.draw = int.Parse(Request.QueryString["draw"])?null:0;

            List<Models.Student> students = new List<Models.Student>();
            students.Add(new Models.Student { Id = 1, Name = "Mike", SurName = "Mikey", ClassRoom = "8A" });
            students.Add(new Models.Student { Id = 2, Name = "John", SurName = "Salary", ClassRoom = "8B" });
            students.Add(new Models.Student { Id = 3, Name = "Steve", SurName = "Brown", ClassRoom = "7A" });

            string filterName = Request.QueryString["name"];
            string filterSurName = Request.QueryString["surname"];
            string filterClassroom = Request.QueryString["classroom"];

            var result = from s in students
                         where (string.IsNullOrEmpty(filterName) || s.Name.Equals(filterName))
                         && (string.IsNullOrEmpty(filterSurName) || s.SurName.Equals(filterSurName))
                         && (string.IsNullOrEmpty(filterClassroom) || s.ClassRoom.Equals(filterClassroom))
                         select s;
            dataTable.data = result.ToArray();
            dataTable.recordsTotal = students.Count;
            dataTable.recordsFiltered = result.Count();
            return Json(dataTable, JsonRequestBehavior.AllowGet);
        }
    }
}