using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MaterialDesignFixedHintTextBox.Models
{
    public class StudentsGradesModel : INotifyPropertyChanged
    {
        private int _ID;
        public int ID
        {
            get => this._ID;
            set
            {
                if (value == this._ID) return;
                this._ID = value;
                OnPropertyChanged(nameof(ID));
            }
        }

        private int _StudentID;
        public int StudentID
        {
            get => this._StudentID;
            set
            {
                if (value == this._StudentID) return;
                this._StudentID = value;
                OnPropertyChanged(nameof(StudentID));
            }
        }

        private string _StudentsGrade;
        public string StudentsGrade
        {
            get => this._StudentsGrade;
            set
            {
                if (value == this._StudentsGrade) return;
                this._StudentsGrade = value;
                OnPropertyChanged(nameof(StudentsGrade));
            }
        }

        //************************************************************************************************************************<<<<<<<<<>>>>>
        //************************************************************************************************************************<<<<<<<<<>>>>>
        //************************************************************************************************************************<<<<<<<<<>>>>>


        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
