using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BO;
using DAL;
using System.Data;

namespace ASPWebApplication
{
    public partial class Employee : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        protected void butSave_Click(object sender, EventArgs e)
        {
            BO.Employee emp = new BO.Employee();
            emp.ID = Convert.ToInt32(txtID.Text);
            emp.Name = txtName.Text;
            emp.Age = Convert.ToInt32(txtAge.Text);
            emp.Salary = Convert.ToDecimal(txtSalary.Text);
            emp.Did = Convert.ToInt32(txtDid.Text);
            emp.DOJ = Convert.ToDateTime(txtDOJ.Text);
            DAL.EmployeeDal.SaveEmployee(emp);
            DisplayEmployee();
            ClearForm();
        }

        protected void butUpdate_Click (object sender, EventArgs e)
        {
            BO.Employee emp = new BO.Employee();
            emp.ID = Convert.ToInt32(txtID.Text);
            emp.Name = txtName.Text;
            emp.Age = Convert.ToInt32(txtAge.Text);
            emp.Salary = Convert.ToDecimal(txtSalary.Text);
            emp.Did = Convert.ToInt32(txtDid.Text);
            emp.DOJ = Convert.ToDateTime(txtDOJ.Text);
            DAL.EmployeeDal.UpdateEmployee(emp);
            DisplayEmployee();
            ClearForm();
        }

        protected void butSelect_Click(object sender, EventArgs e)
        {
            DisplayEmployee();
        }

        protected void butDelete_Click(object sender, EventArgs e)
        {
            BO.Employee emp = new BO.Employee();
            emp.ID = Convert.ToInt32(txtID.Text);
            DAL.EmployeeDal.DeleteEmployee(emp);
            DisplayEmployee();
            ClearForm();
        }
        void DisplayEmployee()
        {
            BO.Employee emp = new BO.Employee();
            DataTable dt = DAL.EmployeeDal.DisplayEmployee();
            GvDisplayEmp.DataSource = dt;
            GvDisplayEmp.DataBind();
        }

        void ClearForm()
        {
            txtName.Text = string.Empty;
            txtAge.Text = string.Empty;
            txtSalary.Text = string.Empty;
            txtDid.Text = string.Empty;
            txtDOJ.Text = string.Empty;
        }
    }
}