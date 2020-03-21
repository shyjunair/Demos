using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult Students()
        {
            using (var context = new ShyjuDB())
            {
                var res = context.p_GetStudent(0);
                var students = from s in res
                               where s.SchoolId != 2
                               select new SudentDTO
                               {
                                   Id = s.Id,
                                   Name = s.Name,
                                   Address = s.Address,
                                   DOB = s.DOB
                               };
                return View(students.ToList());
            }            
        }
    }
}