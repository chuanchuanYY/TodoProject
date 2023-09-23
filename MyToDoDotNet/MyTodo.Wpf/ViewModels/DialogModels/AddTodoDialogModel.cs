using MyTodo.Wpf.Common;
using MyTodo.Wpf.Models;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTodo.Wpf.ViewModels.DialogModels
{
	public class AddTodoDialogModel :BindableBase, IDialogAware
	{

        public AddTodoDialogModel()
        {
			status = new List<string>();
			Status.Add("代办");
			Status.Add("完成");

			RequestCloseCommand = new DelegateCommand(() => {
				RequestClose?.Invoke(new DialogResult(ButtonResult.Cancel));
			});
			SubmitCommand = new DelegateCommand(  ()=> {
				
				//var todoHelper = new TodoHelper();
				var newtodo = new Models.Todo(OldTodoId, UserManage.GetUser()
					, TodoTitle, Content, IsCompleted.Equals("代办") ? false : true);
				//await todoHelper.Add(newtodo);
				var key = new DialogParameters();
				key.Add("AddTodoResult",newtodo);
				RequestClose?.Invoke(new DialogResult(ButtonResult.OK,key));
			});	

		}
        public string Title =>"";
		private Guid OldTodoId;
		public event Action<IDialogResult> RequestClose;
		public DelegateCommand RequestCloseCommand { get; set; }
		public DelegateCommand SubmitCommand { get; set; }
		private List<string> status;
		public List<string> Status
		{
			get { return status; }
			set { SetProperty(ref status, value); }
		}

		#region 
		private string isCompleted;
		public string IsCompleted
		{
			get { return isCompleted; }
			set { SetProperty(ref isCompleted, value); }
		}

		private string todoTitle;
		public string TodoTitle
		{
			get { return todoTitle; }
			set { SetProperty(ref todoTitle, value); }
		}
		private string content;
		public string Content
		{
			get { return content; }
			set { SetProperty(ref content, value); }
		}
		#endregion
		public bool CanCloseDialog()
		{
			return true;
		}

		public void OnDialogClosed()
		{
			
		}

		public void OnDialogOpened(IDialogParameters parameters)
		{
			var oldTodo=parameters.GetValue<Todo>("oldTodo");
			if (oldTodo != null)
			{
				IsCompleted = oldTodo.IsCompleted?"完成":"代办";
				TodoTitle=oldTodo.Title;
				Content = oldTodo.Content==null?"":oldTodo.Content;
				OldTodoId=oldTodo.Id;
			}
		}
	}
}
