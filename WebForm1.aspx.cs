using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication3
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ShowEmployees();
        }

        protected void ButtonInsert_Click(object sender, EventArgs e)
        {
            BLogic bl = new BLogic();
            Employee emp = new Employee();
            emp.eid = int.Parse(TextBoxEid.Text);
            emp.ename = TextBoxEname.Text;
            emp.esal = int.Parse(TextBoxEsal.Text);

            if(bl.AddEmployee(emp))
            {
                ShowEmployees();
            }



        }

        protected void ButtonDelete_Click(object sender, EventArgs e)
        {
            BLogic bl = new BLogic();
            Employee emp = new Employee();
            emp.eid = int.Parse(TextBoxEid.Text);
           

            if (bl.DelEmployee(emp))
            {
                ShowEmployees();
            }
        }

        protected void ButtonUpdate_Click(object sender, EventArgs e)
        {
            BLogic bl = new BLogic();
            Employee emp = new Employee();
            emp.eid = int.Parse(TextBoxEid.Text);
            emp.ename = TextBoxEname.Text;
            emp.esal = int.Parse(TextBoxEsal.Text);

            if (bl.UpdaEmployee(emp))
            {
                ShowEmployees();
            }
        }

        protected void ButtonShow_Click(object sender, EventArgs e)
        {
            ShowEmployees();
        }

        protected void ButtonFind_Click(object sender, EventArgs e)
        {
            Employee emp = new Employee();
            emp.eid = int.Parse(TextBoxEid.Text);
            emp = new BLogic().GetEmployeeById(emp);
            TextBoxEname.Text = emp.ename;
            TextBoxEsal.Text = emp.esal.ToString();
        }
        public void ShowEmployees()
        {
            GridView1.DataSource = new BLogic().GetEmployees().ToList();
            GridView1.DataBind();
        }
    }
}