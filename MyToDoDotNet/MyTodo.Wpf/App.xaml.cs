using DryIoc;
using MyTodo.Wpf.ViewModels;
using MyTodo.Wpf.ViewModels.DialogModels;
using MyTodo.Wpf.Views;
using MyTodo.Wpf.Views.Dialogs;
using Prism.DryIoc;
using Prism.Ioc;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace MyTodo.Wpf
{
	/// <summary>
	/// Interaction logic for App.xaml
	/// </summary>
	public partial class App : PrismApplication
	{
		protected override Window CreateShell()
		{
			return Container.Resolve<MainView>();
		}
		
		protected override void RegisterTypes(IContainerRegistry containerRegistry)
		{
			containerRegistry.RegisterForNavigation<HomeView, HomeViewModel>("Home");
			containerRegistry.RegisterForNavigation<TodoView, TodoViewModel>("Todo");
			containerRegistry.RegisterForNavigation<MemoView, MemoViewModel>("Memo");
			containerRegistry.RegisterForNavigation<SettingView,SettingViewModel>("Setting");
			//Register Dialog
			containerRegistry.RegisterDialog<AddTodoDialog, AddTodoDialogModel>();
			containerRegistry.RegisterDialog<AddMemoDialog, AddMemoDialogModel>();
			containerRegistry.RegisterDialog<LoginDialog, LoginDialogModel>();
		}

		protected override void OnInitialized()
		{
			Container.Resolve<IDialogService>().ShowDialog("LoginDialog", callback => {

				if (callback.Result != ButtonResult.OK)
				{
					Environment.Exit(0);
				}
			});
			base.OnInitialized();
		}
	}
}
