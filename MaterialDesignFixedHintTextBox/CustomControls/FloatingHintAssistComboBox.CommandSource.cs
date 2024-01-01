using System;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Input;

namespace FloatingHintAssistComboBox.CustomControls
{
    public partial class FloatingHintAssistComboBox : ICommandSource
    {
        public ICommand Command
        {
            get => (ICommand)GetValue(CommandProperty);
            set => SetValue(CommandProperty, value);
        }

        // Using a DependencyProperty as the backing store for Command.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CommandProperty =
            DependencyProperty.Register(
                nameof(Command),
                typeof(ICommand),
                typeof(FloatingHintAssistComboBox),
                new PropertyMetadata(null));

        public object CommandParameter
        {
            get => GetValue(CommandParameterProperty);
            set => SetValue(CommandParameterProperty, value);
        }

        // Using a DependencyProperty as the backing store for CommandParameter.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CommandParameterProperty =
            DependencyProperty.Register(
                nameof(CommandParameter),
                typeof(object),
                typeof(FloatingHintAssistComboBox),
                new PropertyMetadata(null));

        public IInputElement CommandTarget
        {
            get => (IInputElement)GetValue(CommandTargetProperty);
            set => SetValue(CommandTargetProperty, value);
        }

        // Using a DependencyProperty as the backing store for CommandTarget.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CommandTargetProperty =
            DependencyProperty.Register(
                nameof(CommandTarget),
                typeof(IInputElement),
                typeof(FloatingHintAssistComboBox),
                new PropertyMetadata(null));

        public bool IsButtonVisibility
        {
            get => (bool)GetValue(IsButtonVisibilityProperty);
            set => SetValue(IsButtonVisibilityProperty, value);
        }

        // Using a DependencyProperty as the backing store for IsButtonVisibility.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsButtonVisibilityProperty =
            DependencyProperty.Register(
                nameof(IsButtonVisibility),
                typeof(bool),
                typeof(FloatingHintAssistComboBox),
                new PropertyMetadata(true));

        public object ButtonContent
        {
            get => GetValue(ButtonContentProperty);
            set => SetValue(ButtonContentProperty, value);
        }

        // Using a DependencyProperty as the backing store for ButtonContent.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ButtonContentProperty =
            DependencyProperty.Register(
                nameof(ButtonContent),
                typeof(object),
                typeof(FloatingHintAssistComboBox),
                new PropertyMetadata(null));

        public override void OnApplyTemplate()
        {
            FrameworkElement main = (FrameworkElement)GetTemplateChild("PART_MainPanel");
            CompositeCollection ccoll = (CompositeCollection)main.FindResource("source");
            ButtonBase butt = (ButtonBase)main.FindResource("button");
            ComboBoxItem cbi = (ComboBoxItem)ccoll[0];
            CollectionContainer collcon = (CollectionContainer)ccoll[1];

            butt.SetBinding(ButtonBase.CommandProperty, new Binding() { Path = new PropertyPath(CommandProperty), Source = this });
            butt.SetBinding(ButtonBase.CommandParameterProperty, new Binding() { Path = new PropertyPath(CommandParameterProperty), Source = this });
            butt.SetBinding(ButtonBase.CommandTargetProperty, new Binding() { Path = new PropertyPath(CommandTargetProperty), Source = this, Converter = targetConverter });
            butt.SetBinding(ContentControl.ContentProperty, new Binding() { Path = new PropertyPath(ButtonContentProperty), Source = this });
            cbi.SetBinding(VisibilityProperty, new Binding() { Path = new PropertyPath(IsButtonVisibilityProperty), Source = this, Converter = booleanToVisibility });

            BindingOperations.SetBinding(collcon, CollectionContainer.CollectionProperty, new Binding() { Path = new PropertyPath(ItemsSourceProperty), Source = this });

            ItemsControl comboBox = (ItemsControl)GetTemplateChild("comboBox");
            Items = comboBox.Items;
        }

        private static readonly BooleanToVisibilityConverter booleanToVisibility = new BooleanToVisibilityConverter();
        private readonly CommandTargetConverter targetConverter;

        private class CommandTargetConverter : IValueConverter
        {
            private readonly IInputElement inputElement;
            public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
            {
                return value ?? inputElement;
            }

            public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            {
                throw new NotImplementedException();
            }

            public CommandTargetConverter(IInputElement inputElement)
            {
                this.inputElement = inputElement;
            }
        }

        public ItemCollection Items
        {
            get => (ItemCollection)GetValue(ItemsProperty);
            private set => SetValue(ItemsPropertyKey, value);
        }

        // Using a DependencyProperty as the backing store for Items.  This enables animation, styling, binding, etc...
        public static readonly DependencyPropertyKey ItemsPropertyKey =
            DependencyProperty.RegisterReadOnly(
                nameof(Items),
                typeof(ItemCollection),
                typeof(FloatingHintAssistComboBox),
                new PropertyMetadata(null));

        public static readonly DependencyProperty ItemsProperty = ItemsPropertyKey.DependencyProperty;
    }
}
