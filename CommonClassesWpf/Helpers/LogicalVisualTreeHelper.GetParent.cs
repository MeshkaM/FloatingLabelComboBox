using System;
using System.Windows;

namespace CommonClassesWpf.Helpers
{
    public static partial class LogicalVisualTreeHelper
    {
        public static T GetParent<T>(this DependencyObject child, int level)
            where T : DependencyObject
        {
            if (child is null)
                throw new ArgumentNullException(nameof(child));

            if (level < 1)
                throw new ArgumentOutOfRangeException(nameof(level));

            DependencyObject parent = child;
            T result;

            do
            {
                result = parent as T;
                if (!(result is null))
                {
                    level--;
                    if (level == 0)
                    {
                        return result;
                    }
                }
                child = parent;
                parent = System.Windows.Media.VisualTreeHelper.GetParent(child)
                    ?? LogicalTreeHelper.GetParent(child);
            } while (!(parent is null));

            return null;
        }
        public static T GetParent<T>(this DependencyObject child)
            where T : DependencyObject
            => child.GetParent<T>(1);
         public static DependencyObject GetParent(this DependencyObject child, int level)
            => child.GetParent<DependencyObject>(level);
         public static DependencyObject GetParent(this DependencyObject child)
            => child.GetParent(1);
   }
}
