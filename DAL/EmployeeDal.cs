using System;
using System.Collections.Generic;
using BO;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace DAL
{
    public static class EmployeeDal
    {
        static string dbConnection = ConfigurationManager.ConnectionStrings["EmpConnection"].ConnectionString;
        public static void SaveEmployee(Employee emp)
        {
            using (SqlConnection conn = new SqlConnection(dbConnection))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SPInsertEmployee", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@eid", emp.ID);
                cmd.Parameters.AddWithValue("@ename", emp.Name);
                cmd.Parameters.AddWithValue("@age", emp.Age);
                cmd.Parameters.AddWithValue("@salary", emp.Salary);
                cmd.Parameters.AddWithValue("@did", emp.Did);
                cmd.Parameters.AddWithValue("@doj", emp.DOJ);
                cmd.ExecuteNonQuery();
            }
        }

        public static DataTable DisplayEmployee()
        {
            using (SqlConnection conn = new SqlConnection(dbConnection))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SPSelectEmployee", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        public static void UpdateEmployee(Employee emp)
        {
            using (SqlConnection conn = new SqlConnection(dbConnection))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SPUpdateEmployee", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@eid", emp.ID);
                cmd.Parameters.AddWithValue("@ename", emp.Name);
                cmd.Parameters.AddWithValue("@age", emp.Age);
                cmd.Parameters.AddWithValue("@salary", emp.Salary);
                cmd.Parameters.AddWithValue("@did", emp.Did);
                cmd.Parameters.AddWithValue("@doj", emp.DOJ);
                cmd.ExecuteNonQuery();
            }
        }

        public static void DeleteEmployee(Employee emp)
        {
            using (SqlConnection conn = new SqlConnection(dbConnection))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SPdeleteEmployee", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@eid", emp.ID);
                cmd.ExecuteNonQuery();
            }
        }

        public static empBO DisplayEmployeesUsingDataReader()
        {
            List<Department> depts = new List<Department>();
            List<Employee> emps = new List<Employee>();
            empBO empbo = new empBO();
            using (SqlConnection conn = new SqlConnection(dbConnection))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SPSelectEmployee", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Employee emp = new Employee();
                    emp.ID = dr["eid"] == DBNull.Value ? 0 : Convert.ToInt32(dr["eid"]);
                    emp.Name = dr["ename"].ToString();
                    emp.Age = dr["age"] == DBNull.Value ? 0 : Convert.ToInt32(dr["age"]);
                    emp.Salary = dr["salary"] == DBNull.Value ? 0 : Convert.ToDecimal(dr["salary"]);
                    emp.Did = dr["did"] == DBNull.Value ? 0 : Convert.ToInt32(dr["did"]);
                    emp.DOJ = dr["doj"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(dr["doj"]);
                    emps.Add(emp);
                }
                empbo.emp = emps;
                dr.NextResult();
                while (dr.Read())
                {
                    Department dpt = new Department();
                    dpt.Did = dr["did"] == DBNull.Value ? 0 : Convert.ToInt32(dr["did"]);
                    dpt.Dname = dr["dname"].ToString();
                    dpt.Ddesg = dr["desg"].ToString();
                    depts.Add(dpt);
                }
                empbo.dept = depts;
                return empbo;
            }
        }

        public static DataTable DisplayEmployeeUsingDataAdapter()
        {

            using (SqlConnection conn = new SqlConnection(dbConnection))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SPSelectEmployee", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                da.Fill(ds);
                dt = ds.Tables[0];
                return dt;
            }
        }

        public static empBO DisplayEmployeesUsingDataAdapter()
        {
            empBO emps = new empBO();
            using (SqlConnection conn = new SqlConnection(dbConnection))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SPSelectEmployee", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                da.Fill(ds);
                List<Employee> emplist = new List<Employee>();
                dt = ds.Tables[0];
                foreach (DataRow dr in dt.Rows)
                {
                    Employee emp = new Employee();
                    emp.ID = dr["eid"] == DBNull.Value ? 0 : Convert.ToInt32(dr["eid"]);
                    emp.Name = dr["ename"].ToString();
                    emp.Age = dr["age"] == DBNull.Value ? 0 : Convert.ToInt32(dr["age"]);
                    emp.Salary = dr["salary"] == DBNull.Value ? 0 : Convert.ToDecimal(dr["salary"]);
                    emp.Did = dr["did"] == DBNull.Value ? 0 : Convert.ToInt32(dr["did"]);
                    emp.DOJ = dr["doj"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(dr["doj"]);
                    emplist.Add(emp);
                }
                emps.emp = emplist;

                List<Department> deptlist = new List<Department>();
                dt = ds.Tables[1];
                foreach (DataRow dr in dt.Rows)
                {
                    Department dept = new Department();
                    dept.Did = Convert.ToInt32(dr["did"]);
                    dept.Dname = dr["dname"].ToString();
                    dept.Ddesg = dr["desg"].ToString();
                    deptlist.Add(dept);
                }
                emps.dept = deptlist;
                return emps;
            }
        }

        public static int ScalarValue(Employee emp)
        {
            int id1 = 0;
            using (SqlConnection conn = new SqlConnection(dbConnection))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SPScalarValue", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ename", emp.Name);
                cmd.Parameters.AddWithValue("@Age", emp.Age);
                cmd.Parameters.AddWithValue("@Salary", emp.Salary);
                cmd.Parameters.AddWithValue("@did", emp.Did);
                cmd.Parameters.AddWithValue("@doj", emp.DOJ);
                Object id = cmd.ExecuteScalar();
                id1 = Convert.ToInt32(id);
                return id1;
            }
        }

        public static void InsertTables(Tb1PKtoTb2FKBO insert)
        {
            using (SqlConnection conn = new SqlConnection(dbConnection))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SPTb1PKtoTb2FK", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ename", insert.Name);
                cmd.Parameters.AddWithValue("@age", insert.Age);
                cmd.Parameters.AddWithValue("@salary", insert.Salary);
                cmd.Parameters.AddWithValue("@did", insert.Did);
                cmd.Parameters.AddWithValue("@doj", insert.DOJ);
                cmd.Parameters.AddWithValue("@dname", insert.Dname);
                cmd.Parameters.AddWithValue("@desg", insert.Ddesg);
                cmd.ExecuteNonQuery();
            }
        }

        public static int FindName(Employee emp)
        {
            using (SqlConnection conn = new SqlConnection(dbConnection))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SPFindName", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter prm = new SqlParameter();
                prm.ParameterName = "@ename";
                prm.Value = emp.Name;
                cmd.Parameters.Add(prm);
                Object obb1 = cmd.ExecuteScalar();
                int id = Convert.ToInt32(obb1);
                return id;
            }
        }

        public static void MultipleRecords(List<Employee> emp)
        {
            using (SqlConnection conn = new SqlConnection(dbConnection))
            {
                conn.Open();
                foreach (var e in emp)
                {
                    SqlCommand cmd = new SqlCommand("SPInsertEmployee", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ename", e.Name);
                    cmd.Parameters.AddWithValue("@age", e.Age);
                    cmd.Parameters.AddWithValue("@salary", e.Salary);
                    cmd.Parameters.AddWithValue("@did", e.Did);
                    cmd.Parameters.AddWithValue("@doj", e.DOJ);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void CustomTable(int id)
        {

        }

        public static void DeleteUser(Employee emp)
        {
            using (SqlConnection conn = new SqlConnection(dbConnection))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SPDeleteIFCond", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@eid", emp.ID);
                cmd.ExecuteScalar();
            }
        }

        public static void DeleteAge(Employee emp)
        {
            using(SqlConnection conn = new SqlConnection(dbConnection))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SPDeleteAge", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@eid", emp.ID);
                cmd.ExecuteScalar();
            }
        }

        public static void UpdateSalary()
        {
            using(SqlConnection conn = new SqlConnection(dbConnection))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SPUpdateSalaryIFcond", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
            }
        }
    }
}