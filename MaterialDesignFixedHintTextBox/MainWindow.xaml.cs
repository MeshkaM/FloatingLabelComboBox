using MaterialDesignFixedHintTextBox.Models;
using MaterialDesignFixedHintTextBox.ViewModels;
using System.Windows;
using System.Windows.Data;

namespace FloatingLabelComboBox
{
    public partial class MainWindow : Window/*, INotifyPropertyChanged*/
    {
        //private readonly DAL dal;
        //private readonly ObservableCollection<StudentModel> students;
        //private readonly ObservableCollection<StudentsGradesModel> studentsGrades;
        //private readonly List<string> grades;

        //// Add an index to keep track of the current position
        //private int currentIndex = 0;

        private readonly StudentsViewModel vm;
        private readonly CollectionViewSource grades;
        public MainWindow()
        {
            InitializeComponent();

            grades = (CollectionViewSource)FindResource(nameof(grades));
            vm = (StudentsViewModel)FindResource(nameof(vm));
            ChangeFilter(null);

            //DataContext = this; // Set the DataContext to this MainWindow

            //dal = new DAL();
            //students = new ObservableCollection<StudentModel>(dal.LoadStudents());
            //studentsGrades = new ObservableCollection<StudentsGradesModel>(dal.LoadStudentsGrades());
            //grades = new List<string>(dal.LoadGrades());

            //CmbStudentName.ItemsSource = students;
            //CmbStudentGrade.ItemsSource = grades;

            //// Set the initial selected item
            //SelectedStudent = studentsGrades[currentIndex];
        }

        private void ChangeFilter(int? studentId)
        {
            if (studentId is null)
            {
                grades.View.Filter = _ => false;
            }
            else
            {
                int id = studentId.Value;
                grades.View.Filter = obj => obj is StudentsGradesModel studentsGrades &&
                                            studentsGrades.StudentID == id;
            }

            grades.View.MoveCurrentToFirst();
        }

        private void OnSelectedStudentChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            ChangeFilter((CmbStudentName.SelectedItem as StudentModel)?.Id);
        }

        //private void RepeatButton_Click(object sender, RoutedEventArgs e)
        //{
        //    // Check the sender to determine which button was clicked
        //    if (sender == NavigateNextButton)
        //    {
        //        // Increment the index and ensure it doesn't exceed the bounds of the list
        //        currentIndex = Math.Min(currentIndex + 1, studentsGrades.Count - 1);
        //    }
        //    else if (sender == NavigatePreviousButton)
        //    {
        //        // Decrement the index and ensure it doesn't go below 0
        //        currentIndex = Math.Max(currentIndex - 1, 0);
        //    }

        //    // Update the selected item in the ComboBox
        //    SelectedStudent = studentsGrades[currentIndex];
        //}


        ////************************************************************************************************************************<<<<<<<<<>>>>>
        ////************************************************************************************************************************<<<<<<<<<>>>>>
        ////************************************************************************************************************************<<<<<<<<<>>>>>


        //private StudentsGradesModel _selectedStudent;
        //public StudentsGradesModel SelectedStudent
        //{
        //    get => _selectedStudent;
        //    set
        //    {
        //        _selectedStudent = value;
        //        OnPropertyChanged();
        //    }
        //}

        //private ObservableCollection<string> _Grade;
        //public ObservableCollection<string> Grade
        //{
        //    get => _Grade;
        //    set
        //    {
        //        _Grade = value;
        //        OnPropertyChanged();
        //    }
        //}

        ////------------------------------------------------------------------------------------------------------------------------------------------------------------------

        //public event PropertyChangedEventHandler PropertyChanged;

        //private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        //{
        //    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        //}

    }
}
