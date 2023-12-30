using MaterialDesignFixedHintTextBox.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MaterialDesignFixedHintTextBox
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public List<StudentModel> Students { get; set; }
        public List<StudentsGradesModel> StudentsGrades { get; set; }


        private StudentModel _selectedStudent;
        public StudentModel SelectedStudent
        {
            get => _selectedStudent;
            set
            {
                _selectedStudent = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

}
