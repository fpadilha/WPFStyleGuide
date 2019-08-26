using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace Fluxonaut.UI.Components
{
    public class UIButtons
    {
        public static object GetIcon(DependencyObject obj)
        {
            return (object)obj.GetValue(IconProperty);
        }

        public static void SetIcon(DependencyObject obj, object value)
        {
            obj.SetValue(IconProperty, value);
        }

        public static readonly DependencyProperty IconProperty =
            DependencyProperty.RegisterAttached("Icon", typeof(object), typeof(UIButtons), new UIPropertyMetadata(null));



        public static Geometry GetPath(DependencyObject obj)
        {
            return (Geometry)obj.GetValue(PathProperty);
        }

        public static void SetPath(DependencyObject obj, Geometry value)
        {
            obj.SetValue(PathProperty, value);
        }

        public static readonly DependencyProperty PathProperty =
            DependencyProperty.RegisterAttached("Path", typeof(Geometry), typeof(UIButtons), new UIPropertyMetadata(null));


    }
}
