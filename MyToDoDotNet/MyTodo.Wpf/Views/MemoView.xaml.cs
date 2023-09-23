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
	/// MemoView.xaml 的交互逻辑
	/// </summary>
	public partial class MemoView : UserControl
	{
		public MemoView()
		{
			InitializeComponent();
		}

		private void FilteText_Changed(object sender, TextChangedEventArgs e)
		{
			CollectionViewSource.GetDefaultView(memoListView.ItemsSource).Refresh();
		}

		private void CollectionViewSource_Filter(object sender, FilterEventArgs e)
		{
			var Text = SearchBox.Text;
			var memo = e.Item as Memo;
			e.Accepted=memo!.Title.Contains(Text);
		}
	}
}
