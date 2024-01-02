using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace CustomControls
{
    public partial class FloatingHintAssistComboBox : Control
    {
        static FloatingHintAssistComboBox()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(FloatingHintAssistComboBox), new FrameworkPropertyMetadata(typeof(FloatingHintAssistComboBox)));
        }

        public FloatingHintAssistComboBox()
        {
            targetConverter = new CommandTargetConverter(this);
        }

        public static readonly DependencyProperty HintAssistTextProperty =
           DependencyProperty.Register(
               nameof(HintAssistText),
               typeof(string),
               typeof(FloatingHintAssistComboBox),
               new PropertyMetadata("HintAssistText"));

        public string HintAssistText
        {
            get { return (string)GetValue(HintAssistTextProperty); }
            set { SetValue(HintAssistTextProperty, value); }
        }

        public static readonly DependencyProperty HintAssistForegroundProperty =
            DependencyProperty.Register(
                nameof(HintAssistForeground),
                typeof(Brush),
                typeof(FloatingHintAssistComboBox),
                new PropertyMetadata(Brushes.AliceBlue));

        public Brush HintAssistForeground
        {
            get { return (Brush)GetValue(HintAssistForegroundProperty); }
            set { SetValue(HintAssistForegroundProperty, value); }
        }


        public static readonly DependencyProperty HintAssistFontSizeProperty =
            DependencyProperty.Register(
                nameof(HintAssistFontSize),
                typeof(double),
                typeof(FloatingHintAssistComboBox),
                new PropertyMetadata(10.0));

        public double HintAssistFontSize
        {
            get { return (double)GetValue(HintAssistFontSizeProperty); }
            set { SetValue(HintAssistFontSizeProperty, value); }
        }


        public static readonly DependencyProperty TextProperty =
        DependencyProperty.Register(
            nameof(Text),
            typeof(string),
            typeof(FloatingHintAssistComboBox),
            new FrameworkPropertyMetadata(string.Empty, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        public static readonly DependencyProperty ItemsSourceProperty =
        DependencyProperty.Register(
            nameof(ItemsSource),
            typeof(object),
            typeof(FloatingHintAssistComboBox),
            new PropertyMetadata(null));
        public object ItemsSource
        {
            get { return GetValue(ItemsSourceProperty); }
            set { SetValue(ItemsSourceProperty, value); }
        }

        public static readonly DependencyProperty SelectedItemProperty =
        DependencyProperty.Register(
            nameof(SelectedItem),
            typeof(object),
            typeof(FloatingHintAssistComboBox),
            new FrameworkPropertyMetadata(null,
                                          FrameworkPropertyMetadataOptions.BindsTwoWayByDefault,
                                          (PropertyChangedCallback) OnSelectedItemChanged));

        private static void OnSelectedItemChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            SelectionChangedEventArgs args = new SelectionChangedEventArgs(SelectionChangedEvent,
                                                                           new object[] { e.OldValue },
                                                                           new object[] { e.NewValue });
            ((FloatingHintAssistComboBox)d).RaiseEvent(args);
        }

        public object SelectedItem
        {
            get { return GetValue(SelectedItemProperty); }
            set { SetValue(SelectedItemProperty, value); }
        }



        public static readonly DependencyProperty SelectedValueProperty =
        DependencyProperty.RegisterAttached(
            nameof(SelectedValue),
            typeof(object),
            typeof(FloatingHintAssistComboBox),
            new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
        public object SelectedValue
        {
            get { return GetValue(SelectedValueProperty); }
            set { SetValue(SelectedValueProperty, value); }
        }


        public static readonly DependencyProperty DisplayMemberPathProperty =
        DependencyProperty.Register(
            nameof(DisplayMemberPath),
            typeof(string),
            typeof(FloatingHintAssistComboBox),
            new PropertyMetadata(null));
        public string DisplayMemberPath
        {
            get { return GetValue(DisplayMemberPathProperty).ToString(); }
            set { SetValue(DisplayMemberPathProperty, value); }
        }


        public static readonly DependencyProperty SelectedValuePathProperty =
        DependencyProperty.Register(
            nameof(SelectedValuePath),
            typeof(string),
            typeof(FloatingHintAssistComboBox),
            new PropertyMetadata(null));
        public string SelectedValuePath
        {
            get => GetValue(SelectedValuePathProperty).ToString();
            set => SetValue(SelectedValuePathProperty, value);
        }



        public static RoutedEvent SelectionChangedEvent =
            EventManager.RegisterRoutedEvent(
                nameof(SelectionChanged),
                RoutingStrategy.Bubble,
                typeof(SelectionChangedEventHandler),
                typeof(FloatingHintAssistComboBox));

        public event SelectionChangedEventHandler SelectionChanged
        {
            add => AddHandler(SelectionChangedEvent, value);
            remove => RemoveHandler(SelectionChangedEvent, value);
        }

        private void ComboBoxSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            RaiseEvent(new RoutedEventArgs(SelectionChangedEvent, this));
        }

    }
}
