using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using WebAPICRUD.Models;
using System.Linq;
using System.Data.Entity;

namespace WebAPICRUD.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class EmployeeController : ApiController
    {
            //public string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            //public List<EmployeeModal> getData()
            //{
            //    List<EmployeeModal> employeeList = new List<EmployeeModal>();
            //    using (SqlConnection conn = new SqlConnection(connectionString))
            //    {
            //        string query = "select * from [dbo].[Employee]";
            //        conn.Open();
            //        using (SqlCommand command = new SqlCommand(query, conn))
            //        {
            //            SqlDataReader reader = command.ExecuteReader();
            //            while (reader.Read())
            //            {
            //                EmployeeModal emp = new EmployeeModal();
            //                emp.EmpId = Convert.ToInt32(reader.GetValue(0).ToString());
            //                emp.EmpName = reader.GetValue(1).ToString();
            //                emp.Email = reader.GetValue(2).ToString();
            //                emp.Salary = Convert.ToInt32(reader.GetValue(3).ToString());
            //                employeeList.Add(emp);
            //            }
            //        }
            //    }
            //    return employeeList;
            //}
           //[System.Web.Mvc.HttpGet]
            public async Task<List<Employee>> Get()
            {
                List<Employee> employeeList = new List<Employee>();
                //using (SqlConnection conn = new SqlConnection(connectionString))
                //{
                //    string query = "select * from [dbo].[Employee]";
                //    conn.Open();
                //    using (SqlCommand command = new SqlCommand(query, conn))
                //    {
                //        SqlDataReader reader = command.ExecuteReader();
                //        while (reader.Read())
                //        {
                //            EmployeeModal emp = new EmployeeModal();
                //            emp.EmpId = Convert.ToInt32(reader.GetValue(0).ToString());
                //            emp.EmpName = reader.GetValue(1).ToString();
                //            emp.Email = reader.GetValue(2).ToString();
                //            emp.Salary = Convert.ToInt32(reader.GetValue(3).ToString());
                //            employeeList.Add(emp);
                //        }
                //    }
                //}
                using (var context = new UsersEntities())
                {
                    employeeList = await context.Employee.ToListAsync();
                }
                return employeeList;
                //return Request.CreateResponse(HttpStatusCode.OK,employeeList);
            }

            public Employee Get(int id)
            {
                Employee emp = new Employee();
                //using (SqlConnection con = new SqlConnection(connectionString))
                //{
                //    con.Open();
                //    SqlCommand cmd = new SqlCommand("Select * from Employee where EmpId=" + id, con);
                //    cmd.Parameters.AddWithValue("@id", emp.EmpId);
                //    SqlDataReader reader = cmd.ExecuteReader();
                //    while (reader.Read())
                //    {
                //        emp.EmpId = Convert.ToInt32(reader.GetValue(0).ToString());
                //        emp.EmpName = reader.GetValue(1).ToString();
                //        emp.Email = reader.GetValue(2).ToString();
                //        emp.Salary = Convert.ToInt32(reader.GetValue(0).ToString());
                //    }
                //    return emp;
                //}
                using (var context = new UsersEntities())
                {
                    var employ = context.Employee.FirstOrDefault(e => e.EmpId == id);
                    emp = (Employee)employ;
                }
                return emp;
            }
            [HttpPost]
            public bool Post([FromBody]Employee employee)
            {
                //try
                //{
                //    using (SqlConnection con = new SqlConnection(connectionString))
                //    {
                //        con.Open();
                //        SqlCommand cmd = new SqlCommand("addEmployee", con);
                //        cmd.CommandType = CommandType.StoredProcedure;

                //        cmd.Parameters.AddWithValue("@EmpId", employee.EmpId);
                //        cmd.Parameters.AddWithValue("@EmpName", employee.EmpName);
                //        cmd.Parameters.AddWithValue("@Email", employee.Email);
                //        cmd.Parameters.AddWithValue("@Salary", employee.Salary);

                //        cmd.ExecuteNonQuery();
                //        con.Close();

                //    }
                //    var message = Request.CreateResponse(HttpStatusCode.Created, employee);
                //    message.Headers.Location = new Uri(Request.RequestUri + employee.EmpId.ToString());
                //    return true;
                //}
                //catch (Exception error)
                //{
                //    //return Request.CreateErrorResponse(HttpStatusCode.BadRequest, error);
                //    return false;
                //}
                try
                {
                    using (var context = new UsersEntities())
                    {
                        context.Employee.Add(new Employee() 
                        { 
                            EmpId = employee.EmpId,
                            EmpName = employee.EmpName,
                            Email = employee.Email,
                            Salary = employee.Salary

                        });
                        context.SaveChanges();
                    }
                    return true;               
                }
                catch(Exception error)
                {
                    return false;
                }
            }
                
            
           [HttpDelete]
            public bool Delete(int id)
            {
                try
                {
                    //using (SqlConnection con = new SqlConnection(connectionString))
                    //{
                    //    SqlCommand cmd = new SqlCommand("deleteEmployee", con);
                    //    cmd.CommandType = CommandType.StoredProcedure;
                    //    cmd.Parameters.AddWithValue("@EmpId", id);
                    //    con.Open();
                    //    cmd.ExecuteNonQuery();
                    //    con.Close();
                    //    return true;
                    //    //return Request.CreateResponse(HttpStatusCode.OK ,"Record Deleted successfully");
                    //}
                       using (var context = new UsersEntities())

                        {
                            var emp = context.Employee.FirstOrDefault(e => e.EmpId == id);
                            context.Employee.Remove(emp);
                            context.SaveChanges();
                            return true;
                        }
                }
                catch (Exception error)
                {
                    return false;
                    //return Request.CreateErrorResponse(HttpStatusCode.BadRequest, error);
                }
               
            }
            [HttpPut]
            public IHttpActionResult Put(int id, [FromBody] Employee employee)
            {
                
                    //using (SqlConnection con = new SqlConnection(connectionString))
                    //{
                    //    con.Open();
                    //    SqlCommand cmd = new SqlCommand("updateEmployee", con);
                    //    cmd.CommandType = CommandType.StoredProcedure;

                    //    cmd.Parameters.AddWithValue("@EmpId", employee.EmpId);
                    //    cmd.Parameters.AddWithValue("@EmpName", employee.EmpName);
                    //    cmd.Parameters.AddWithValue("@Email", employee.Email);
                    //    cmd.Parameters.AddWithValue("@Salary", employee.Salary);
                    //    con.Open();
                    //    cmd.ExecuteNonQuery();
                    //}
                    //return Request.CreateResponse(HttpStatusCode.OK, employee);
                    if (!ModelState.IsValid)
                        return BadRequest("Not a valid model");
                    using (var context = new UsersEntities())
                    {
                        var existingEmployee = context.Employee.FirstOrDefault(emp => emp.EmpId == id);
                        if (existingEmployee != null)
                        {
                            existingEmployee.EmpId = employee.EmpId;
                            existingEmployee.EmpName = employee.EmpName;
                            existingEmployee.Email = employee.Email;
                            existingEmployee.Salary = employee.Salary;

                            context.SaveChanges();
                        }
                        else
                        {
                            return NotFound();
                        }
                        return Ok();
                    }               
            }

    }
       
}
