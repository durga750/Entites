using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace WebApplication3
{
    public class BLogic
    {
        SqlConnection con;
        SqlCommand com;
        SqlDataReader dr;
        DataTable dt;
        public BLogic()
        {
       //string cs = @"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = C:\Users\ojas\source\repos\WebApplication3\WebApplication3\App_Data\Database1.mdf; Integrated Security = True";
            string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
            con = new SqlConnection(cs);       
            com = new SqlCommand();
            com.Connection = con;
            con.Close();
        }

       public bool AddEmployee(Employee Emp)
        {
            com.CommandText = string.Format($"insert into emptable values({Emp.eid},'{Emp.ename}',{Emp.esal})");
            con.Open();
            int value = com.ExecuteNonQuery();
            con.Close();

            return value == 1;
        }

        public bool DelEmployee(Employee Emp)
        {
            com.CommandText = string.Format($"delete from emptable where eid={Emp.eid}");
            con.Open();
            int value = com.ExecuteNonQuery();
            con.Close();

            return value == 1;
        }

        public bool UpdaEmployee(Employee Emp)
        {
            com.CommandText = string.Format($"Update emptable set ename='{Emp.ename}',esal={Emp.esal} where eid={Emp.eid} ");
            con.Open();
            int value = com.ExecuteNonQuery();
            con.Close();

            return value == 1;
        }

        public List<Employee> GetEmployees()
        {


            List<Employee> employees = new List<Employee>();
            com.CommandText = "Select * from emptable";
            con.Open();
            dr = com.ExecuteReader();

            while (dr.Read())
            {
                Employee emp = new Employee();
                emp.eid = int.Parse(dr[0].ToString());
                emp.ename = dr[1].ToString();
                emp.esal = int.Parse(dr[2].ToString());
                employees.Add(emp);
            }
            con.Close();
            return employees;
        }

        public Employee GetEmployeeById(Employee emp)
        {
            com.CommandText = string.Format($"select * from emptable where eid={emp.eid}");
            con.Open();
            dr = com.ExecuteReader();
            while (dr.Read())
            {
                emp.eid = int.Parse(dr[0].ToString());
                emp.ename = dr[1].ToString();
                emp.esal = int.Parse(dr[2].ToString());

            }

            con.Close();
            return emp;
        }
    }
}