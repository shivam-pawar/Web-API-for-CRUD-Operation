using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace SMSWebAPI.Models
{
    public class DepartmentDataAccessLayer
    {

        public static string GetConnectionString()
        {
            return Startup.ConnectionString;
        }
        string connectionString = GetConnectionString();
        public IEnumerable<Department> GetAllDepartment()
        {
            List<Department> lstdept = new List<Department>();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spGetAllDepartment", con);
                cmd.CommandType = CommandType.StoredProcedure;

                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    Department department = new Department();
                    department.deptid = Convert.ToInt32(rdr["deptid"]);
                    department.deptname = rdr["deptname"].ToString();
                    department.hod= rdr["hod"].ToString();

                    lstdept.Add(department);
                }
                con.Close();

            }
            return lstdept;
        }

        public void AddDepartment(Department department)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spAddDepartment", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@deptid", department.deptid);
                cmd.Parameters.AddWithValue("@deptname", department.deptname);
                cmd.Parameters.AddWithValue("@hod", department.hod);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public void UpdateDepartment(Department department)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spUpdateDepartment", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@deptid", department.deptid);
                cmd.Parameters.AddWithValue("@deptname", department.deptname);
                cmd.Parameters.AddWithValue("@hod", department.hod);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public Department GetDepartmentData(int deptid)
        {
            Department department = new Department();


            using (SqlConnection con = new SqlConnection(connectionString))
            {

                string sqlQuery = "select * from Department where deptid ="+deptid;
                SqlCommand cmd = new SqlCommand(sqlQuery, con);

                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    department.deptid =Convert.ToInt32(rdr["deptid"]);
                    department.deptname = rdr["deptname"].ToString();
                    department.hod = rdr["hod"].ToString();

                }
                con.Close();

            }
            return department;
        }

        public void DeleteDepartment(int? deptid)
        {

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spDeleteDepartment", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@deptid", deptid);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

    }
}