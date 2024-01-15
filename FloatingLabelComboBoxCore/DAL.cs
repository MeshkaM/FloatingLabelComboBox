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


        //**************************************************************************************************

        public static List<PlacesOfInterest> LoadPlacesOfInterest()
        {
            using (IDbConnection conn = new SqlConnection(ConnString))
            {
                if (conn.State == ConnectionState.Closed) conn.Open();
                return conn.Query<PlacesOfInterest>("SELECT * FROM PlacesOfInterest").ToList();
            }
        }

        public static List<CountriesModel> LoadCountries()
        {
            using (IDbConnection conn = new SqlConnection(ConnString))
            {
                if (conn.State == ConnectionState.Closed) conn.Open();
                return conn.Query<CountriesModel>("SELECT * FROM Countries").ToList();
            }
        }

        public static List<ProvincesModel> LoadProvinces()
        {
            using (IDbConnection conn = new SqlConnection(ConnString))
            {
                if (conn.State == ConnectionState.Closed) conn.Open();
                return conn.Query<ProvincesModel>("SELECT * FROM Provinces").ToList();
            }
        }

        public static List<DistrictsModel> LoadDistricts()
        {
            using (IDbConnection conn = new SqlConnection(ConnString))
            {
                if (conn.State == ConnectionState.Closed) conn.Open();
                return conn.Query<DistrictsModel>("SELECT * FROM Districts").ToList();
            }
        }
    }
}
