using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MaterialDesignFixedHintTextBox.Models
{
    public class PlacesOfInterest : INotifyPropertyChanged
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

        private string _CountryName;
        public string CountryName
        {
            get => this._CountryName;
            set
            {
                if (value == this._CountryName) return;
                this._CountryName = value;
                OnPropertyChanged(nameof(CountryName));
            }
        }

        private int _ProvinceID;
        public int ProvinceID
        {
            get => this._ProvinceID;
            set
            {
                if (value == this._ProvinceID) return;
                this._ProvinceID = value;
                OnPropertyChanged(nameof(ProvinceID));
            }
        }

        private int _DistrictID;
        public int DistrictID
        {
            get => this._DistrictID;
            set
            {
                if (value == this._DistrictID) return;
                this._DistrictID = value;
                OnPropertyChanged(nameof(DistrictID));
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
