using MyTodo.Common;
using MyTodo.Wpf.Models;
using Prism.Mvvm;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using MyTodo.Wpf.Common;
using System.Diagnostics;
using Prism.Commands;
using Prism.Services.Dialogs;

namespace MyTodo.Wpf.ViewModels
{
    class HomeViewModel:BindableBase
    {

        public HomeViewModel(IDialogService dialogService)
        {
			this.dialogService = dialogService;
			todoHelper = new TodoHelper();
			memoHelper = new MemoHelper();
			todoList = new ObservableCollection<Todo>();
            memoList = new ObservableCollection<Memo>();
			initData();

            OpenDialog = new DelegateCommand<string>(name => {
                dialogService.ShowDialog(name, async callback => {
                    if (callback.Result == ButtonResult.OK)
                    {
                        var memo= callback.Parameters.GetValue<Memo>("AddMemoResult");
                        if(memo!=null)
                        await memoHelper.Add(memo);
                        var todo = callback.Parameters.GetValue<Todo>("AddTodoResult");
                        if(todo!=null)
                            await todoHelper.Add(todo);
                        initData();
                    }
                });
            });
			IsCompletedCommand = new DelegateCommand<object>(async args => {

                var values = args as object[];
                var newIsCompleted = values[0] is bool;
				var todoid = (Guid)values[1];
                var todo= TodoList.First(t=>t.Id.Equals(todoid));
                if (todo != null)
                {
                    var newtodo = new Todo(todo.Id,todo.User,
                        todo.Title,todo.Content,newIsCompleted);
                     await  todoHelper.Update(newtodo);
                    initData();
				}
			});
            IsCompletedCommandForMemo = new DelegateCommand<object>(async args => {

				var values = args as object[];
				var newIsCompleted = values[0] is bool;
				var memoid = (Guid)values[1];
				var memo = MemoList.First(t => t.Id.Equals(memoid));
				if (memo != null)
				{
					var newmemo = new Memo(memo.Id, memo.User,
						memo.Title, memo.Content, newIsCompleted);
					await memoHelper.Update(newmemo);
					initData();
				}
			});

            ModifyTotoCommand = new DelegateCommand<object>((arg) => {
                var oldTodo=arg as Todo;
                var key = new DialogParameters();
                key.Add("oldTodo", oldTodo);
                dialogService.ShowDialog("AddTodoDialog", key, async callback => {
                    if (callback.Result == ButtonResult.OK)
                    {
                        var newTodo=  callback.Parameters.GetValue<Todo>("AddTodoResult");
                        await todoHelper.Update(newTodo);
                        initData();
					}
                });
            });

			ModifyMemoCommand = new DelegateCommand<object>((arg) => {
				var oldMemo = arg as Memo;
				var key = new DialogParameters();
				key.Add("oldMemo", oldMemo);
				dialogService.ShowDialog("AddMemoDialog", key, async callback => {
					if (callback.Result == ButtonResult.OK)
					{
						var newMemo = callback.Parameters.GetValue<Memo>("AddMemoResult");
						await memoHelper.Update(newMemo);
						initData();
					}
				});
			});
		}
        private TodoHelper todoHelper;
        private MemoHelper memoHelper;
		private async void initData()
        {
			TodoList.Clear();
            memoList.Clear();
            var todos=await todoHelper.GetAll();
		    foreach (var item in todos)
            {
                if(item.IsCompleted==false)
                TodoList.Add(item);
            }
             
            var memos=await memoHelper.GetAll();
            foreach (var item in memos)
            {
                if(item.IsCompleted==false)
                MemoList.Add(item);
            }
            Summary = todos.Count() + memos.Count();

			CompleteCount= todos.Where(t => t.IsCompleted == true).Count()
                + memos.Where(m=>m.IsCompleted==true).Count();
            CompletionRate = (int)(((double)CompleteCount / (double)Summary) * 100);
            MemoCount = memos.Count();
		}

       
        #region 汇总 已完成 完成比例 备忘录
        private int summary;
        public int Summary
        {
            get { return summary; }
            set { SetProperty(ref summary, value); }
        }
        private int completeCount;
        public int CompleteCount
        {
            get { return completeCount; }
            set { SetProperty(ref completeCount, value); }
        }

        private int  completionRate;
        public int  CompletionRate
        {
            get { return completionRate; }
            set { SetProperty(ref completionRate, value); }
        }
        private int memoCount;
        public int MemoCount
        {
            get { return memoCount; }
            set { SetProperty(ref memoCount, value); }
        }
        #endregion
        private ObservableCollection<Todo> todoList;
        public ObservableCollection<Todo> TodoList
		{
            get { return todoList; }
            set { SetProperty(ref todoList, value); }
        }

        private ObservableCollection<Memo> memoList;
		private readonly IDialogService dialogService;

		public ObservableCollection<Memo> MemoList
        {
            get { return memoList; }
            set { SetProperty(ref memoList, value); }
        }

		#region 命令
        public DelegateCommand<string> OpenDialog { get; set; }
        /// <summary>
        /// togglebutton is true
        /// </summary>
        public DelegateCommand<object> IsCompletedCommand { get;  set; }
        public DelegateCommand<object>IsCompletedCommandForMemo { get; set; }
        public DelegateCommand<object> ModifyTotoCommand { get; set; }  
        public DelegateCommand<object> ModifyMemoCommand { get; set; }  
		#endregion

	}
}
