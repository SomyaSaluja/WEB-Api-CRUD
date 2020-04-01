using System;
using System.Collections.Generic;
using System.Data;
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
                        emp.Salary = Convert.ToInt32(reader.GetValue(3).ToString());
                        employeeList.Add(emp);
                    }
                }
            }
            return employeeList;
        }

        public void AddEmployee(EmployeeModal employee)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("addEmployee", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@EmpId", employee.EmpId);
                cmd.Parameters.AddWithValue("@EmpName", employee.EmpName);
                cmd.Parameters.AddWithValue("@Email", employee.Email);
                cmd.Parameters.AddWithValue("@Salary", employee.Salary);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public void UpdateEmployee(EmployeeModal employee)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("updateEmployee", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@EmpId", employee.EmpId);
                cmd.Parameters.AddWithValue("@EmpName", employee.EmpName);
                cmd.Parameters.AddWithValue("@Email", employee.Email);
                cmd.Parameters.AddWithValue("@Salary", employee.Salary);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

       

        public void DeleteEmployee(int id)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("deleteEmployee", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@EmpId", id);
                con.Open();
                cmd.ExecuteNonQuery();
                
            }
        }  
    }
}