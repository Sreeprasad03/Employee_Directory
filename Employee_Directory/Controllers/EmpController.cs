using Employee_Directory.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static Employee_Directory.Models.Emp;

namespace Employee_Directory.Controllers
{
    public class EmpController : Controller
    {
        // GET: Emp
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Emp()
        {
            return View();
        }
        public JsonResult EmpDetails(Details_Param U)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Emp dbhandle = new Emp();
                    List<Emp.Status1> empList = dbhandle.Emp_Details(U); // Expecting List<Status1>

                    ModelState.Clear();

                    return Json(empList, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                // Log the exception (ex) if needed
            }

            return Json(null, JsonRequestBehavior.AllowGet); // Return something in case of an error
        }
        public JsonResult EmpLocation()
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Emp dbhandle = new Emp();
                    List<Emp.Loc> empList = dbhandle.EmpLocation(); // Expecting List<Status1>

                    ModelState.Clear();

                    return Json(empList, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                // Log the exception (ex) if needed
            }

            return Json(null, JsonRequestBehavior.AllowGet); // Return something in case of an error
        }
        public JsonResult EmpDep()
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Emp dbhandle = new Emp();
                    List<Emp.Loc> empList = dbhandle.EmpDep(); // Expecting List<Status1>

                    ModelState.Clear();

                    return Json(empList, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                // Log the exception (ex) if needed
            }

            return Json(null, JsonRequestBehavior.AllowGet); // Return something in case of an error
        }

        public JsonResult Emp_Details(Details_Paramss U)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Emp dbhandle = new Emp();
                    List<Emp.Status1> empList = dbhandle.Emp_DetailsCall(U); // Expecting List<Status1>

                    ModelState.Clear();

                    return Json(empList, JsonRequestBehavior.AllowGet);

                }
            }
            catch (Exception ex)
            {
                // Log the exception (ex) if needed
            }

            return Json(null, JsonRequestBehavior.AllowGet); // Return something in case of an error
        }
    }
}