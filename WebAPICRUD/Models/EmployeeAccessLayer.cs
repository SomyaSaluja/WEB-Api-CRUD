using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebAPICRUD.Models
{
    public class EmployeeAccessLayer
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