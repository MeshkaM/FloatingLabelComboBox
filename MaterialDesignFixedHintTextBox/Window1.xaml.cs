using MaterialDesignFixedHintTextBox.Models;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace MaterialDesignFixedHintTextBox
{
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
            studentsGradesCBox.Items.Filter = _ => false;
        }

        private async void OnSelectionStudentChanged(object sender, SelectionChangedEventArgs e)
        {
            if (!IsLoaded)
                await Task.Delay(100);
            ComboBox comboBox = (ComboBox)sender;
            if (comboBox.SelectedItem is StudentModel student)
            {
                int id = student.Id;
                studentsGradesCBox.Items.Filter = obj => obj is StudentsGradesModel sg && sg.StudentID == id;
            }
            else
            {
                studentsGradesCBox.Items.Filter = _ => false;
            }
            studentsGradesCBox.SelectedIndex = 0;
        }
    }
}
