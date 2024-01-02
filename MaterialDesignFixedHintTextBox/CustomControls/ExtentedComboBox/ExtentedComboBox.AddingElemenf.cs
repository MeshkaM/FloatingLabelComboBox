using Microsoft.Windows.Themes;
using System;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace   CustomControls
{
    public partial class ExtentedComboBox : ComboBox
    {
        public object AddingContent
        {
            get { return (object)GetValue(AddingContentProperty); }
            set { SetValue(AddingContentProperty, value); }
        }

        // Using a DependencyProperty as the backing store for AddingContent.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty AddingContentProperty =
            DependencyProperty.Register(
                nameof(AddingContent),
                typeof(object),
                typeof(ExtentedComboBox),
                new PropertyMetadata(null));



        public DataTemplate AddingContentTemplate
        {
            get { return (DataTemplate)GetValue(AddingContentTemplateProperty); }
            set { SetValue(AddingContentTemplateProperty, value); }
        }

        // Using a DependencyProperty as the backing store for AddingContentTemplate.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty AddingContentTemplateProperty =
            DependencyProperty.Register(
                nameof(AddingContentTemplate),
                typeof(DataTemplate),
                typeof(ExtentedComboBox),
                new PropertyMetadata(null));


        static ExtentedComboBox()
        {
            NullToVisibilityMultiBinding = new MultiBinding();
            NullToVisibilityMultiBinding.Converter = new NullToVisibility();
            NullToVisibilityMultiBinding.Bindings.Add(new Binding() { RelativeSource = RelativeSource.Self, Path = new PropertyPath(ContentControl.ContentProperty) });
            NullToVisibilityMultiBinding.Bindings.Add(new Binding() { RelativeSource = RelativeSource.Self, Path = new PropertyPath(ContentControl.ContentTemplateProperty) });
        }
        private static readonly MultiBinding NullToVisibilityMultiBinding;

        private class NullToVisibility : IMultiValueConverter
        {
            public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
            {
                if( values is null || values.Length==0 || values.All(v => v is null))
                    return Visibility.Collapsed;
                return Visibility.Visible;
            }

            public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
            {
                throw new NotImplementedException();
            }
        }
    }
}
