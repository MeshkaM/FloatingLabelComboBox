using Simplified;

namespace MaterialDesignFixedHintTextBox.Models
{
    public class StudentModel : ViewModelBase
    {
        public int Id { get => Get<int>(); set => Set(value); }
        public string StudentName{ get => Get<string>(); set => Set(value); }
    }
}
