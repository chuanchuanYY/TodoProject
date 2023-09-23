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
using System.Windows.Shapes;
using System.Xml;

namespace MyTodo.Wpf.Views
{
	/// <summary>
	/// MainView.xaml 的交互逻辑
	/// </summary>
	public partial class MainView : Window
	{
		public MainView()
		{
			InitializeComponent();

			// 设置点击窗体的其他区域 侧边栏关闭
			this.MouseDown += (s, e) => {
				if (e.ChangedButton == MouseButton.Left)
				{
					if (!LeftDrawerOpen.IsMouseOver)
					{
						LeftDrawerOpen.IsChecked = false;
					}
				}
			};
			//设置顶部菜单（横条）鼠标左键拖拽
			this.TopZoon.MouseDown += (s, e) => {
				if (e.LeftButton == MouseButtonState.Pressed)
				{
					this.DragMove();
				}
				if (e.ClickCount == 2)
				{
					if (this.WindowState == WindowState.Minimized)
						this.WindowState = WindowState.Normal;
					else if (this.WindowState == WindowState.Maximized)
						this.WindowState = WindowState.Normal;
					else this.WindowState = WindowState.Maximized;
				}
			};
	

			this.Min.Click += (s, e) =>
			{
				this.WindowState = WindowState.Minimized;
			};
			this.Max.Click += (s, e) => {
				if (this.WindowState == WindowState.Minimized)
					this.WindowState = WindowState.Normal;
				else if(this.WindowState==WindowState.Maximized)
					this.WindowState = WindowState.Normal;
				else this.WindowState = WindowState.Maximized;
			};
			this.Close.Click += (s, e) => {
				this.Close();
			};
		}

		
	}
}
