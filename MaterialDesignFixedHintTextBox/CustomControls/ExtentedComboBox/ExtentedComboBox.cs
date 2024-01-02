using CommonClassesWpf.Helpers;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;

namespace CustomControls
{
    public partial class ExtentedComboBox : ComboBox
    {
        public ExtentedComboBox()
        {
            SetResourceReference(StyleProperty, typeof(ComboBox));
            addingControl.SetBinding(ContentControl.ContentProperty, new Binding() { Source = this, Path = new PropertyPath(AddingContentProperty) });
            addingControl.SetBinding(ContentControl.ContentTemplateProperty, new Binding() { Source = this, Path = new PropertyPath(AddingContentTemplateProperty) });
            addingControl.SetBinding(VisibilityProperty, NullToVisibilityMultiBinding);
        }

        public const string PopupTemplateName = "PART_Popup";
        private Popup _dropDownPopup;
        private ContentControl addingControl = new ContentControl();
        //private ContentControl addingControl = new ContentControl()
        //{
        //    Content =new Button() { Content="Add"}
        //};

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            if (addingControl is null)
                return;

            _dropDownPopup = GetTemplateChild(PopupTemplateName) as Popup;
            if (!(_dropDownPopup is null))
            {

                ItemsPresenter presenter = _dropDownPopup.GetFirstChild<ItemsPresenter>();
                ScrollViewer scroll = presenter.GetParent<ScrollViewer>();
                DependencyObject parent = scroll.GetParent(2);
                if (parent is PrivateGrid)
                    return;


                PrivateGrid childGrid = new PrivateGrid();
                childGrid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(0, GridUnitType.Auto) });
                childGrid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(1, GridUnitType.Star) });

                switch (parent)
                {
                    case ContentControl contentControl:
                        {
                            contentControl.Content = childGrid;
                            break;
                        }
                    case Decorator decorator:
                        {
                            decorator.Child = childGrid;
                            break;
                        }
                    case Panel panel:
                        {
                            int index = panel.Children.IndexOf(scroll);
                            panel.Children[index] = childGrid;

                            CopyValueDependencyProperties(scroll, childGrid, panelsAttachedProperties);
                            break;
                        }

                    default:
                        break;
                }

                Grid.SetRow(addingControl, 0);
                Grid.SetRow(scroll, 1);
                childGrid.Children.Add(addingControl);
                childGrid.Children.Add(scroll);
            }
        }

        private class PrivateGrid : Grid { }


        private static readonly IReadOnlyList<DependencyProperty> panelsAttachedProperties = Array.AsReadOnly(new DependencyProperty[]
        {
            Panel.ZIndexProperty,
            FlowDirectionProperty,

            Grid.RowProperty,
            Grid.ColumnProperty,
            Grid.RowSpanProperty,
            Grid.ColumnSpanProperty,
            Grid.IsSharedSizeScopeProperty,

            Canvas.BottomProperty,
            Canvas.LeftProperty,
            Canvas.RightProperty,
            Canvas.TopProperty,

            DockPanel.DockProperty
        });
        private void CopyValueDependencyProperties(DependencyObject source, DependencyObject target, IEnumerable<DependencyProperty> properties)
        {
            foreach (var property in properties)
            {
                var value = source.ReadLocalValue(property);
                if (value == DependencyProperty.UnsetValue)
                {
                    continue;
                }


                if (BindingOperations.GetBindingBase(source, property) is BindingBase binding)
                {
                    BindingOperations.SetBinding(source, property, binding);
                }
                else
                {
                    source.SetValue(property, value);
                }
            }
        }
    }
}
