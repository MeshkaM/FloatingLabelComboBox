using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MaterialDesignFixedHintTextBox.Models
{
    public class DistrictsModel : INotifyPropertyChanged
    {
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

        private string _DistrictName;
        public string DistrictName
        {
            get => this._DistrictName;
            set
            {
                if (value == this._DistrictName) return;
                this._DistrictName = value;
                OnPropertyChanged(nameof(DistrictName));
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}