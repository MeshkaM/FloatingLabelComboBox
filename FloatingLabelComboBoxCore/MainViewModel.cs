using MaterialDesignFixedHintTextBox.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace FloatingLabelComboBox
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

        private List<PlacesOfInterest> _PlacesOfInterest;
        public List<PlacesOfInterest> PlacesOfInterest
        {
            get => _PlacesOfInterest;
            set
            {
                _PlacesOfInterest = value;
                OnPropertyChanged();
            }
        }

        private List<CountriesModel> _Countries;
        public List<CountriesModel> Countries
        {
            get => _Countries;
            set
            {
                _Countries = value;
                OnPropertyChanged();
            }
        }

        private List<ProvincesModel> _Provinces;
        public List<ProvincesModel> Provinces
        {
            get => _Provinces;
            set
            {
                _Provinces = value;
                OnPropertyChanged();
            }
        }

        private List<DistrictsModel> _Districts;
        public List<DistrictsModel> Districts
        {
            get => _Districts;
            set
            {
                _Districts = value;
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
