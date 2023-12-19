using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MaterialDesignFixedHintTextBox.Models
{
    public class StudentModel : INotifyPropertyChanged
    {
        private int _studentId;
        public int StudentId
        {
            get => this._studentId;
            set
            {
                if (value == this._studentId) return;
                this._studentId = value;
                OnPropertyChanged(nameof(_studentId));
            }
        }

        private string _studentName;
        public string StudentName
        {
            get => this._studentName;
            set
            {
                if (value == this._studentName) return;
                this._studentName = value;
                OnPropertyChanged(nameof(_studentName));
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

        //protected bool SetField<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
        //{
        //    if (EqualityComparer<T>.Default.Equals(field, value)) return false;
        //    field = value;
        //    OnPropertyChanged(propertyName);
        //    return true;
        //}
    }
}
