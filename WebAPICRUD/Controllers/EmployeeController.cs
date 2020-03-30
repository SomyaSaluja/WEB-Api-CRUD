using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPICRUD.Models;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Web.Mvc;

namespace WebAPICRUD.Controllers
{
    public class EmployeeController : ApiController
    {
            public string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            public List<EmployeeModal> getData()
            {
                List<EmployeeModal> employeeList = new List<EmployeeModal>();
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "select * from [dbo].[Employee]";
                    conn.Open();
                    using (SqlCommand command = new SqlCommand(query, conn))
                    {
                        SqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            EmployeeModal emp = new EmployeeModal();
                            emp.EmpId = Convert.ToInt32(reader.GetValue(0).ToString());
                            emp.EmpName = reader.GetValue(1).ToString();
                            emp.Email = reader.GetValue(2).ToString();
                            emp.Salary = Convert.ToInt32(reader.GetValue(0).ToString());
                            employeeList.Add(emp);
                        }
                    }
                }
                return employeeList;
            } 
    }
       
}
