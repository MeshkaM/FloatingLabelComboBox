using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using static System.Windows.Media.VisualTreeHelper;

namespace CommonClassesWpf.Helpers
{
    public static partial class LogicalVisualTreeHelper
    {
        public static IEnumerable<DependencyObject> GetChildren(this DependencyObject parent)
        {
            if (parent is null)
                throw new ArgumentNullException(nameof(parent));

            Queue<DependencyObject> queue = new Queue<DependencyObject>(16);
            HashSet<DependencyObject> all = new HashSet<DependencyObject>(16);
            queue.Enqueue(parent);
            while (queue.Count != 0)
            {
                DependencyObject current = queue.Dequeue();
                yield return current;

                int count = GetChildrenCount(current);
                for (int i = 0; i < count; i++)
                {
                    var child = GetChild(current, i);
                    if (all.Add(child))
                        queue.Enqueue(child);
                }
                foreach (DependencyObject child in LogicalTreeHelper.GetChildren(current))
                {
                    if (all.Add(child))
                        queue.Enqueue(child);
                }
            }
        }
        public static IEnumerable<T> GetChildren<T>(this DependencyObject parent)
           where T : DependencyObject
            => parent.GetChildren().OfType<T>();

        public static T GetFirstChild<T>(this DependencyObject parent)
           where T : DependencyObject
            => (T)parent.GetChildren().FirstOrDefault(child => child is T);
    }
}
