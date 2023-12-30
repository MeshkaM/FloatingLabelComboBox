using Dapper;
using MaterialDesignFixedHintTextBox.Models;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace MaterialDesignFixedHintTextBox
{
    public class DAL
    {
        private static readonly string ConnString = "Data Source=(local);Initial Catalog=CollegeDB;Integrated Security=True";

        //**********************************************************************************************************************************************

        public static List<StudentModel> LoadStudents()
        {
            using (IDbConnection conn = new SqlConnection(ConnString))
            {
                if(conn.State == ConnectionState.Closed) conn.Open();
                return conn.Query<StudentModel>("SELECT * FROM Students").ToList();
            }
        }

        public static List<StudentsGradesModel> LoadStudentsGrades()
        {
            using (IDbConnection conn = new SqlConnection(ConnString))
            {
                if (conn.State == ConnectionState.Closed) conn.Open();
                return conn.Query<StudentsGradesModel>("SELECT * FROM StudentsGrades").ToList();
            }
        }
    }
}
