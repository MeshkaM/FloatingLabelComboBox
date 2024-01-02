using Simplified;

namespace MaterialDesignFixedHintTextBox.Models
{
    public class StudentsGradesModel : ViewModelBase
    {
        public int Id { get => Get<int>(); set => Set(value); }

        public int StudentID { get => Get<int>(); set => Set(value); }
        public string StudentsGrade { get => Get<string>(); set => Set(value); }
        public string Subject { get => Get<string>(); set => Set(value); }

        //public string DisplayMember { get => Get<string>(); private set => Set(value); }

        //protected override void OnPropertyChanged(string propertyName, object oldValue, object newValue)
        //{
        //    base.OnPropertyChanged(propertyName, oldValue, newValue);
        //    DisplayMember = $"{Subject}: {StudentsGrade}";
        //}
    }
}
