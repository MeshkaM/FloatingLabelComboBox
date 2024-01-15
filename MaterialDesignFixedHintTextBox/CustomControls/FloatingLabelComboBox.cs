using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
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
            DependencyProperty.Register("LabelForeground", typeof(Brush), typeof(FloatingLabelComboBox), new PropertyMetadata(new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFD6931B"))));

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


        public static readonly DependencyProperty TextProperty =
        DependencyProperty.Register("Text", typeof(string), typeof(FloatingLabelComboBox), new FrameworkPropertyMetadata(string.Empty, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        public static readonly DependencyProperty ItemsSourceProperty =
        DependencyProperty.Register("ItemsSource", typeof(object), typeof(FloatingLabelComboBox), new PropertyMetadata(null));
        public object ItemsSource
        {
            get { return GetValue(ItemsSourceProperty); }
            set { SetValue(ItemsSourceProperty, value); }
        }

        public static readonly DependencyProperty SelectedItemProperty =
        DependencyProperty.Register("SelectedItem", typeof(object), typeof(FloatingLabelComboBox), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, new PropertyChangedCallback(OnSelectedItemChanged)));
        public object SelectedItem
        {
            get { return GetValue(SelectedItemProperty); }
            set { SetValue(SelectedItemProperty, value); }
        }
        private static void OnSelectedItemChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            FloatingLabelComboBox cc = d as FloatingLabelComboBox;
            if (cc != null) cc.OnPropertyChanged(nameof(SelectedItem));
        }



        public static readonly DependencyProperty SelectedValueProperty =
        DependencyProperty.RegisterAttached("SelectedValue", typeof(object), typeof(FloatingLabelComboBox), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, new PropertyChangedCallback(OnSelectedValueChanged)));
        public object SelectedValue
        {
            get { return GetValue(SelectedValueProperty); }
            set { SetValue(SelectedValueProperty, value); }
        }
        private static void OnSelectedValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            FloatingLabelComboBox cc = d as FloatingLabelComboBox;
            if (cc != null) cc.OnPropertyChanged(nameof(SelectedValue));
        }



        public static readonly DependencyProperty DisplayMemberPathProperty =
        DependencyProperty.Register("DisplayMemberPath", typeof(string), typeof(FloatingLabelComboBox), new PropertyMetadata(null));
        public string DisplayMemberPath
        {
            get { return GetValue(DisplayMemberPathProperty).ToString(); }
            set { SetValue(DisplayMemberPathProperty, value); }
        }


        public static readonly DependencyProperty SelectedValuePathProperty =
        DependencyProperty.Register("SelectedValuePath", typeof(string), typeof(FloatingLabelComboBox), new PropertyMetadata(null));
        public string SelectedValuePath
        {
            get { return GetValue(SelectedValuePathProperty).ToString(); }
            set { SetValue(SelectedValuePathProperty, value); }
        }



        public static RoutedEvent SelectionChangedEvent = 
            EventManager.RegisterRoutedEvent("SelectionChanged", RoutingStrategy.Bubble, typeof(SelectionChangedEventHandler), typeof(FloatingLabelComboBox));

        public event SelectionChangedEventHandler SelectionChanged
        {
            add { AddHandler(SelectionChangedEvent, value); }
            remove { RemoveHandler(SelectionChangedEvent, value); }
        }

        private void ComboBoxSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            RaiseEvent(new RoutedEventArgs(SelectionChangedEvent, this));
        }


        //******************************************************************************************************************************************************************************************************************************************************************************


        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
