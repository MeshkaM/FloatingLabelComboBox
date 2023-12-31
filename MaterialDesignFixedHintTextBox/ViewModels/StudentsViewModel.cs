using MaterialDesignFixedHintTextBox.Models;
using Simplified;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaterialDesignFixedHintTextBox.ViewModels
{
    public class StudentsViewModel : ViewModelBase
    {
        private readonly DAL dal;
        public IReadOnlyList<string> Grades { get; }
        public ReadOnlyObservableCollection<StudentModel> Students { get; }
        public ReadOnlyObservableCollection<StudentsGradesModel> StudentsGrades { get; }

        private readonly List<string> privateGrades;
        private readonly ObservableCollection<StudentModel> privateStudents;
        private readonly ObservableCollection<StudentsGradesModel> privateStudentsGrades;

        public StudentsViewModel()
        {
            dal = new DAL();
            privateGrades = dal.LoadGrades();
            privateStudents = new ObservableCollection<StudentModel>(dal.LoadStudents());
            privateStudentsGrades = new ObservableCollection<StudentsGradesModel>(dal.LoadStudentsGrades());
            Grades = privateGrades.AsReadOnly();
            Students = new ReadOnlyObservableCollection<StudentModel>(privateStudents);
            StudentsGrades = new ReadOnlyObservableCollection<StudentsGradesModel>(privateStudentsGrades);
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
    }
}
