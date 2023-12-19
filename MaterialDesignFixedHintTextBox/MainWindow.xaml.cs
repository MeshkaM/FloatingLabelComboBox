using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Documents;
using MaterialDesignFixedHintTextBox.Models;

namespace FloatingLabelComboBox
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private ObservableCollection<StudentModel> _students = new ObservableCollection<StudentModel>();
        public ObservableCollection<StudentModel> students
        {
            get { return _students; }
            set
            {
                _students = value;
                OnPropertyChanged();
            }
        }

        StudentModel _student1 = new StudentModel { StudentId = 1, StudentName = "John Doe" };
        StudentModel _student2 = new StudentModel { StudentId = 2, StudentName = "Jane Doe" };

        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
            LoadStudents();
        }

        private void LoadStudents()
        {
            students.Add(_student1);
            students.Add(_student2);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
