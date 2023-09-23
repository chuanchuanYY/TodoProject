using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MyTodo.Wpf.Extensions
{
	public class ButtonHelper
	{

		#region 给button添加CornerRaious附加属性

		public static CornerRadius GetCornerRadius(DependencyObject obj)
		{
			return (CornerRadius)obj.GetValue(CornerRadiusProperty);
		}

		public static void SetCornerRadius(DependencyObject obj, CornerRadius value)
		{
			obj.SetValue(CornerRadiusProperty, value);
		}

		// Using a DependencyProperty as the backing store for CornerRadius.  This enables animation, styling, binding, etc...
		public static readonly DependencyProperty CornerRadiusProperty =
			DependencyProperty.RegisterAttached("CornerRadius", typeof(CornerRadius), typeof(ButtonHelper), new PropertyMetadata(new CornerRadius(0)));

		#endregion
	}
}
