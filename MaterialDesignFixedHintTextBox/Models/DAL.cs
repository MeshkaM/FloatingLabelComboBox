using Dapper;
using MaterialDesignFixedHintTextBox.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace MaterialDesignFixedHintTextBox
{
    public class DAL
    {
        private static readonly string ConnString = "Data Source=(local);Initial Catalog=CollegeDB;Integrated Security=True";

        private readonly bool isWithoutDB;

        public DAL(bool isWithoutDB) => this.isWithoutDB = isWithoutDB;

        public DAL()
            : this(true)
        { }

        //**********************************************************************************************************************************************

        private static List<StudentModel> students;

        public List<StudentModel> LoadStudents()
        {
            if (isWithoutDB)
            {
                if (students == null)
                {
                    students = new List<StudentModel>()
                    {
                        new StudentModel(){Id = 1, StudentName="First"},
                        new StudentModel(){Id = 2, StudentName="Second"},
                        new StudentModel(){Id = 3, StudentName="Third"},
                    };
                }
                return students;
            }
            using (IDbConnection conn = new SqlConnection(ConnString))
            {
                if (conn.State == ConnectionState.Closed) conn.Open();
                return conn.Query<StudentModel>("SELECT * FROM Students").ToList();
            }
        }

        private static List<StudentsGradesModel> studentsGrades;
        public List<StudentsGradesModel> LoadStudentsGrades()
        {
            if (isWithoutDB)
            {
                if (studentsGrades == null)
                {
                    var students = LoadStudents();
                    var grades = LoadGrades();
                    var subjects = LoadSubjects();
                    studentsGrades = new List<StudentsGradesModel>(students.Count * 2);

                    Random random = new Random();
                    int id = 0;
                    foreach (var student in students)
                    {
                        int countGrades = random.Next(1, 5);
                        int i = 0;
                        foreach (var subject in subjects.OrderBy(_ => random.Next()))
                        {
                            studentsGrades.Add(new StudentsGradesModel()
                            {
                                Id = ++id,
                                StudentID = student.Id,
                                StudentsGrade = grades[random.Next(grades.Count)],
                                Subject = subject,
                            });
                            i++;
                            if (i >= countGrades)
                                break;
                        }
                    }
                }
                return studentsGrades;
            }

            using (IDbConnection conn = new SqlConnection(ConnString))
            {
                if (conn.State == ConnectionState.Closed) conn.Open();
                return conn.Query<StudentsGradesModel>("SELECT * FROM StudentsGrades").ToList();
            }
        }

        private static List<string> grades;
        public List<string> LoadGrades()
        {
            if (isWithoutDB)
            {
                if (grades == null)
                {
                    grades = new List<string>("A A- B+ B B- C+ C C- D+ D D- E".Split()) { };
                }
                return grades;
            }

            using (IDbConnection conn = new SqlConnection(ConnString))
            {
                if (conn.State == ConnectionState.Closed) conn.Open();
                return conn.Query<string>("SELECT * FROM Grades").ToList();
            }

        }
        private static List<string> subjects;
        public List<string> LoadSubjects()
        {
            if (isWithoutDB)
            {
                if (subjects == null)
                {
                    subjects = new List<string>("Mathematics Literature Physics Chemistry Astronomy Music Dancing".Split());
                }
                return subjects;
            }

            using (IDbConnection conn = new SqlConnection(ConnString))
            {
                if (conn.State == ConnectionState.Closed) conn.Open();
                return conn.Query<string>("SELECT * FROM Grades").ToList();
            }

        }
    }
}
