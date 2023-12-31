using MaterialDesignFixedHintTextBox;
using MaterialDesignFixedHintTextBox.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;

namespace FloatingLabelComboBox
{
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private readonly DAL dal;
        private readonly ObservableCollection<StudentModel> students;
        private readonly ObservableCollection<StudentsGradesModel> studentsGrades;
        private readonly List<string> grades;

        // Add an index to keep track of the current position
        private int currentIndex = 0;

        public MainWindow()
        {
            InitializeComponent();
            DataContext = this; // Set the DataContext to this MainWindow

            dal = new DAL();
            students = new ObservableCollection<StudentModel>(dal.LoadStudents());
            studentsGrades = new ObservableCollection<StudentsGradesModel>(dal.LoadStudentsGrades());
            grades = new List<string>(dal.LoadGrades());

            CmbStudentName.ItemsSource = students;
            CmbStudentGrade.ItemsSource = grades;

            // Set the initial selected item
            SelectedStudent = studentsGrades[currentIndex];
        }

        private void RepeatButton_Click(object sender, RoutedEventArgs e)
        {
            // Check the sender to determine which button was clicked
            if (sender == NavigateNextButton)
            {
                // Increment the index and ensure it doesn't exceed the bounds of the list
                currentIndex = Math.Min(currentIndex + 1, studentsGrades.Count - 1);
            }
            else if (sender == NavigatePreviousButton)
            {
                // Decrement the index and ensure it doesn't go below 0
                currentIndex = Math.Max(currentIndex - 1, 0);
            }

            // Update the selected item in the ComboBox
            SelectedStudent = studentsGrades[currentIndex];
        }


        //************************************************************************************************************************<<<<<<<<<>>>>>
        //************************************************************************************************************************<<<<<<<<<>>>>>
        //************************************************************************************************************************<<<<<<<<<>>>>>


        private StudentsGradesModel _selectedStudent;
        public StudentsGradesModel SelectedStudent
        {
            get => _selectedStudent;
            set
            {
                _selectedStudent = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<string> _Grade;
        public ObservableCollection<string> Grade
        {
            get => _Grade;
            set
            {
                _Grade = value;
                OnPropertyChanged();
            }
        }

        //------------------------------------------------------------------------------------------------------------------------------------------------------------------

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
