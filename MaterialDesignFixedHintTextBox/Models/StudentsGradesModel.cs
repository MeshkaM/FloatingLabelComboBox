using Simplified;

namespace MaterialDesignFixedHintTextBox.Models
{
    public class StudentsGradesModel : ViewModelBase
    {
        public int Id { get => Get<int>(); set => Set(value); }

        public int StudentID { get => Get<int>(); set => Set(value); }
        public string StudentsGrade { get => Get<string>(); set => Set(value); }
        public string Subject { get => Get<string>(); set => Set(value); }

        public override string ToString() => $"{Subject}: {StudentsGrade}";
    }
}
