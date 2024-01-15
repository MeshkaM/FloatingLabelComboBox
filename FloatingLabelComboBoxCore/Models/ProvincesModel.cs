using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MaterialDesignFixedHintTextBox.Models
{
    public class ProvincesModel : INotifyPropertyChanged
    {
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

        private string _ProvinceName;
        public string ProvinceName
        {
            get => this._ProvinceName;
            set
            {
                if (value == this._ProvinceName) return;
                this._ProvinceName = value;
                OnPropertyChanged(nameof(ProvinceName));
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
