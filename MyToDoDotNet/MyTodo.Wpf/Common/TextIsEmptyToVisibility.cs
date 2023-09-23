using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace MyTodo.Wpf.Common
{
	public class TextIsEmptyToVisibility : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
	{
			if (targetType != typeof(Visibility)) return value;
		    var str=value as string;
			if (str != null)
			{
				if (str.Length >= 1)
					return Visibility.Hidden;
				else return Visibility.Visible;
			}
			return "";
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return null;
		}
	}
}
