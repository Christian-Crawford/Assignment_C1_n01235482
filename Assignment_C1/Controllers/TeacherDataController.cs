using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Assignment_C1.Models;
using MySql.Data.MySqlClient;


namespace Assignment_C1.Controllers
{
    public class TeacherDataController : ApiController
    {
        //Connecting with the teacher database
        private SchoolDBContext School = new SchoolDBContext();
       
        /// <summary>
        /// Returns a list of teachers in the system
        /// </summary>
        /// <example>GET/api/TeacherData/ShowTeachers</example> </example>
        /// <returns>List of all Teachers and attached information</returns>
        [HttpGet]

        public IEnumerable<Teacher> ShowTeachers()
        {

            MySqlConnection Conn = School.AccessDatabase();

            Conn.Open();

            MySqlCommand cmd = Conn.CreateCommand();

            cmd.CommandText = "Select * from teachers";

            MySqlDataReader ResultSet = cmd.ExecuteReader();

            List<Teacher> Teacher = new List<Teacher> {};

            while (ResultSet.Read())
            {
                int TeacherId = (int)ResultSet["teacherid"];
                string TeacherFname = ResultSet["teacherfname"].ToString();
                string TeacherLname = ResultSet["teacherlname"].ToString();
                string TeacherEmpNum = ResultSet["employeenumber"].ToString();
                string TeacherHireDate = ResultSet["hiredate"].ToString();
                decimal TeacherSal = (decimal)ResultSet["salary"];

                Teacher NewTeacher = new Teacher();
                NewTeacher.TeacherId = TeacherId;
                NewTeacher.TeacherFname = TeacherFname;
                NewTeacher.TeacherLname = TeacherLname;
                NewTeacher.TeacherEmpNum = TeacherEmpNum;
                NewTeacher.TeacherHireDate = TeacherHireDate;
                NewTeacher.TeacherSal = TeacherSal;

                Teacher.Add(NewTeacher);



            }

            Conn.Close();

            return Teacher;


        }
        /// <summary>
        /// Finds a particular Teacher based on Id
        /// </summary>
        /// <param name="id">The id associated with each teacher</param>
        /// <example>GET/api/TeacherData.FindTeacher/3 </example>
        /// <returns>Linda Chan (and rest of file)</returns>
       [HttpGet]
        public Teacher FindTeacher (int id)
        {
           Teacher NewTeacher = new Teacher();

            MySqlConnection Conn = School.AccessDatabase();

            Conn.Open();

            MySqlCommand cmd = Conn.CreateCommand();

            cmd.CommandText = "Select* from teachers where teacherid = " + id;

            MySqlDataReader ResultSet = cmd.ExecuteReader();
        
            while (ResultSet.Read())
            {
                int TeacherId = (int)ResultSet["teacherid"];
                string TeacherFname = ResultSet["teacherfname"].ToString();
                string TeacherLname = ResultSet["teacherlname"].ToString();
                string TeacherEmpNum = ResultSet["employeenumber"].ToString();
                string TeacherHireDate = ResultSet["hiredate"].ToString();
                decimal TeacherSal = (decimal)ResultSet["salary"];


                NewTeacher.TeacherId = TeacherId;
                NewTeacher.TeacherFname = TeacherFname;
                NewTeacher.TeacherLname = TeacherLname;
                NewTeacher.TeacherEmpNum = TeacherEmpNum;
                NewTeacher.TeacherHireDate = TeacherHireDate;
                NewTeacher.TeacherSal = TeacherSal;
            }

            return NewTeacher;

        }
    }
}
