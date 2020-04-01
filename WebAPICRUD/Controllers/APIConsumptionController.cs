using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using WebAPICRUD.Models;

namespace WebAPICRUD.Controllers
{
    public class APIConsumptionController : Controller
    {
        //
        // GET: /APIConsumption/

        public ActionResult Index()
        {
            List<EmployeeModal> employeeList = null;
            HttpClient hc = new HttpClient();
            hc.BaseAddress = new Uri("http://localhost:11590/api/Employee");
            var getEmployeeData = hc.GetAsync("Emp");
            getEmployeeData.Wait();
            
            return View();
        }

    }
}
