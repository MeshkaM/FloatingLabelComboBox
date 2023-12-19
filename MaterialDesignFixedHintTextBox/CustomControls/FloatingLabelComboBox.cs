using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace FloatingLabelComboBox.CustomControls
{
    public class FloatingLabelComboBox : Control
    {
        static FloatingLabelComboBox()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(FloatingLabelComboBox), new FrameworkPropertyMetadata(typeof(FloatingLabelComboBox)));
        }
        public static readonly DependencyProperty LabelTextProperty =
           DependencyProperty.Register("LabelText", typeof(string), typeof(FloatingLabelComboBox), new PropertyMetadata("LabelText"));

        public string LabelText
        {
            get { return (string)GetValue(LabelTextProperty); }
            set { SetValue(LabelTextProperty, value); }
        }

        public static readonly DependencyProperty LabelForegroundProperty =
            DependencyProperty.Register("LabelForeground", typeof(Brush), typeof(FloatingLabelComboBox), new PropertyMetadata(Brushes.AliceBlue));

        public Brush LabelForeground
        {
            get { return (Brush)GetValue(LabelForegroundProperty); }
            set { SetValue(LabelForegroundProperty, value); }
        }


        public static readonly DependencyProperty LabelFontSizeProperty =
            DependencyProperty.Register("LabelFontSize", typeof(double), typeof(FloatingLabelComboBox), new PropertyMetadata(10.0));

        public double LabelFontSize
        {
            get { return (double)GetValue(LabelFontSizeProperty); }
            set { SetValue(LabelFontSizeProperty, value); }
        }

    }
}
