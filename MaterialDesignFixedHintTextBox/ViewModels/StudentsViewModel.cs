using MaterialDesignFixedHintTextBox.Models;
using Simplified;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MaterialDesignFixedHintTextBox.ViewModels
{
    public class StudentsViewModel : ViewModelBase
    {
        private readonly DAL dal;
        public IReadOnlyList<string> Grades { get; }
        public ReadOnlyObservableCollection<StudentModel> Students { get; }
        public ReadOnlyObservableCollection<StudentsGradesModel> StudentsGrades { get; }
        public ReadOnlyObservableCollection<StudentsGradesModel> SelectedStudentsGrades { get; }

        private readonly List<string> privateGrades;
        private readonly ObservableCollection<StudentModel> privateStudents;
        private readonly ObservableCollection<StudentsGradesModel> privateStudentsGrades;
        private readonly ObservableCollection<StudentsGradesModel> privateSelectedStudentsGrades = new ObservableCollection<StudentsGradesModel>();

        public StudentsViewModel()
        {
            dal = new DAL();
            privateGrades = dal.LoadGrades();
            privateStudents = new ObservableCollection<StudentModel>(dal.LoadStudents());
            privateStudentsGrades = new ObservableCollection<StudentsGradesModel>(dal.LoadStudentsGrades());
            Grades = privateGrades.AsReadOnly();
            Students = new ReadOnlyObservableCollection<StudentModel>(privateStudents);
            StudentsGrades = new ReadOnlyObservableCollection<StudentsGradesModel>(privateStudentsGrades);
            SelectedStudentsGrades = new ReadOnlyObservableCollection<StudentsGradesModel>(privateSelectedStudentsGrades);
        }

        public StudentModel SelectedStudent { get => Get<StudentModel>(); set => Set(value); }
        public StudentsGradesModel SelectedStudentsGrade { get => Get<StudentsGradesModel>(); set => Set(value); }

        public RelayCommand RepeatGrade => GetCommand<int>(RepeatGradeExecute, RepeatGradeCanExecute);

        private void RepeatGradeExecute(int parameter)
        {
            int index = privateGrades.IndexOf(SelectedStudentsGrade.StudentsGrade);
            index += parameter;
            index %= privateGrades.Count;
            if (index < 0)
                index += privateGrades.Count;
            SelectedStudentsGrade.StudentsGrade = privateGrades[index];
        }

        private bool RepeatGradeCanExecute(int parameter) => !(SelectedStudentsGrade is null);

        public RelayCommand AddStudent => GetCommand(() => MessageBox.Show("Add Student"));
        public RelayCommand AddGrade => GetCommand(() =>
        {
            MessageBox.Show("Add Grade");
            RefreshSelectedStudentsGrade(SelectedStudent?.Id);
        });

        private void RefreshSelectedStudentsGrade(int? studentId)
        {
            if (studentId is null)
            {
                privateSelectedStudentsGrades.Clear();
                return;
            }
            int id = studentId.Value;
            int i = 0;
            foreach (var studGrade in privateStudentsGrades.Where(sg => sg.StudentID == id))
            {
                if (i < privateSelectedStudentsGrades.Count)
                {
                    privateSelectedStudentsGrades[i] = studGrade;
                }
                else
                {
                    privateSelectedStudentsGrades.Add(studGrade);
                }
                i++;
            }
            while (i < privateSelectedStudentsGrades.Count)
            {
                privateSelectedStudentsGrades.RemoveAt(privateSelectedStudentsGrades.Count - 1);
            }
            SelectedStudentsGrade = SelectedStudentsGrades.Count > 0 ? SelectedStudentsGrades[0] : null;
        }

        protected override void OnPropertyChanged(string propertyName, object oldValue, object newValue)
        {
            base.OnPropertyChanged(propertyName, oldValue, newValue);
            if (propertyName == nameof(SelectedStudent))
            {
                RefreshSelectedStudentsGrade((newValue as StudentModel)?.Id);
            }
        }
    }
}
