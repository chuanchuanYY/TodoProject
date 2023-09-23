using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MyTodo.Wpf.Extensions
{
    /// <summary>
    /// 給radiobutton添加附加属性
    /// </summary>
    class RadioButtonHelper
    {


        public static string GetIconText(DependencyObject obj)
        {
            return (string)obj.GetValue(Property);
        }

        public static void SetIconText(DependencyObject obj, string value)
        {
            obj.SetValue(Property, value);
        }

        // Using a DependencyProperty as the backing store for .  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty Property =
            DependencyProperty.RegisterAttached("IconText", typeof(string), typeof(RadioButtonHelper), new PropertyMetadata(""));


    }
}
