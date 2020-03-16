using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace SMSWebAPI.Models
{
    public class StudentDataAccessLayer
    {
        public static string GetConnectionString()
        {
            return Startup.ConnectionString;
        }
        string connectionString = GetConnectionString();
        public IEnumerable<Student> GetAllStudent()
        {
            List<Student> lststudent = new List<Student>();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spGetAllStudent", con);
                cmd.CommandType = CommandType.StoredProcedure;

                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    Student student = new Student();
                    student.sid = Convert.ToInt32(rdr["sid"]);
                    student.sname = rdr["sname"].ToString();
                    student.emailid = rdr["emailid"].ToString();
                    student.contact = Convert.ToDouble(rdr["contact"]);
                    student.deptid = Convert.ToInt32(rdr["deptid"]);
                    student.deptname = rdr["deptname"].ToString();
                    lststudent.Add(student);
                }
                con.Close();

            }
            return lststudent;
        }

        public void AddStudent(Student student)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spAddStudent", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@sid", student.sid);
                cmd.Parameters.AddWithValue("@sname", student.sname);
                cmd.Parameters.AddWithValue("@emailid", student.emailid);
                cmd.Parameters.AddWithValue("@contact", student.contact);
                cmd.Parameters.AddWithValue("@deptid", student.deptid);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public void UpdateStudent(Student student)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spUpdateStudent", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@sid", student.sid);
                cmd.Parameters.AddWithValue("@sname", student.sname);
                cmd.Parameters.AddWithValue("@emailid", student.emailid);
                cmd.Parameters.AddWithValue("@contact", student.contact);
                cmd.Parameters.AddWithValue("@deptid", student.deptid);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public Student GetStudentData(int sid)
        {
            
            Student student = new Student();

            using (SqlConnection con = new SqlConnection(connectionString))
            {

                string sqlQuery = "select * from Student where sid =" + sid;
                SqlCommand cmd = new SqlCommand(sqlQuery, con);

                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    student.sid = Convert.ToInt32(rdr["sid"]);
                    student.sname = rdr["sname"].ToString();
                    student.emailid = rdr["emailid"].ToString();
                    student.contact = Convert.ToDouble(rdr["contact"]);
                    student.deptid =Convert.ToInt32(rdr["deptid"].ToString());

                }
                con.Close();

            }
            return student;
        }

        public void DeleteStudent(int sid)
        {

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spDeleteStudent", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@sid", sid);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
    }
}
