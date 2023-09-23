using MyTodo.Wpf.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MyTodo.Wpf.Views
{
	/// <summary>
	/// TodoView.xaml 的交互逻辑
	/// </summary>
	public partial class TodoView : UserControl
	{
		public TodoView()
		{
			InitializeComponent();
		}

		private void FilteText_Changed(object sender, TextChangedEventArgs e)
		{
			CollectionViewSource.GetDefaultView(todoListView.ItemsSource).Refresh();
        }

		private void CollectionViewSource_Filter(object sender, FilterEventArgs e)
		{
			var todo=e.Item as Todo;
			var text = SearchBox.Text;
			var condition=FilterCondition.SelectedValue as string;
			switch (condition)
			{
				case "全部":
					e.Accepted = todo!.Title.Contains(text);
					break;
				case "已完成":
					e.Accepted =todo.IsCompleted==true&& todo!.Title.Contains(text);
					break;
				case "未完成":
					e.Accepted = todo.IsCompleted == false&& todo!.Title.Contains(text);
					break;
			}
			
		}

		private void FilterCondition_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			if (todoListView == null) return;
			CollectionViewSource.GetDefaultView(todoListView.ItemsSource).Refresh();
		}
	}
}
