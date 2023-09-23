using MyTodo.Wpf.Common;
using MyTodo.Wpf.Models;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTodo.Wpf.ViewModels
{
	public class TodoViewModel:BindableBase,INavigationAware
	{

        public TodoViewModel(IDialogService dialogService)
        {
			this.dialogService = dialogService;
			todoHelper =new TodoHelper();
			todoList=new ObservableCollection<Todo>();
            initData();
            AddTotoCommand = new DelegateCommand(()=> {

                dialogService.ShowDialog("AddTodoDialog", async callback => {
                    if (callback.Result == ButtonResult.OK)
                    {
                        var newtodo= callback.Parameters.GetValue<Todo>("AddTodoResult");
                        await todoHelper.Add(newtodo);
						initData();
					}
                });
            });


			ModifyTotoCommand = new DelegateCommand<object>((arg) => {
				var values = arg as object[];
				if (values == null) return;
				var oldTodo = new Todo((Guid)values[0],UserManage.GetUser(),
					(string)values[1], (string)values[2], (bool)values[3]);
				var key = new DialogParameters();
				key.Add("oldTodo", oldTodo);
				dialogService.ShowDialog("AddTodoDialog", key, async callback =>
				{
					if (callback.Result == ButtonResult.OK)
					{
						var newTodo = callback.Parameters.GetValue<Todo>("AddTodoResult");
						await todoHelper.Update(newTodo);
						initData();
					}
				});
			});
		}
        private TodoHelper todoHelper;
        private async void initData()
        {
            TodoList.Clear();
            var alltodo= await todoHelper.GetAll();
			if (alltodo == null) return;
			alltodo.ToList().ForEach(t => { TodoList.Add(t); });
		}

		public void OnNavigatedTo(NavigationContext navigationContext)
		{
			initData();
		}

		public bool IsNavigationTarget(NavigationContext navigationContext)
		{
			return true;
		}

		public void OnNavigatedFrom(NavigationContext navigationContext)
		{
			
		}
		#region 筛选相关
		public string[] FilterCondition { get; set; } = {"全部","已完成","未完成" };
        #endregion

        public DelegateCommand AddTotoCommand { get; set; }
		public DelegateCommand<object> ModifyTotoCommand { get; set; }

		private ObservableCollection<Todo> todoList;
		private readonly IDialogService dialogService;

		public ObservableCollection<Todo> TodoList
        {
            get { return todoList; }
            set { SetProperty(ref todoList, value); }
        }
   
    }
}
