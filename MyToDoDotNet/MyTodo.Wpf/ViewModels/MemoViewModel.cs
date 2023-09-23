using MyTodo.Wpf.Common;
using MyTodo.Wpf.Models;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTodo.Wpf.ViewModels
{
	public class MemoViewModel:BindableBase,INavigationAware
	{
		private readonly IDialogService dialogService;
		private MemoHelper memoHelper;
		public MemoViewModel(IDialogService dialogService)
        {
			this.dialogService = dialogService;	
			memoHelper=new MemoHelper();
			memoList = new List<Memo>();
			initData();

			AddMemoCommand = new DelegateCommand(() => {

				dialogService.ShowDialog("AddMemoDialog", async callback => {
					if (callback.Result == ButtonResult.OK)
					{
						var newMemo=callback.Parameters.GetValue<Memo>("AddMemoResult");
					    await	memoHelper.Add(newMemo);
						initData();
					}
				});
			});

			ModifyMemoCommand = new DelegateCommand<object>((arg) => {
				var values = arg as object[];
				if (values == null) return;
				var oldMemo = new Memo((Guid)values[0],UserManage.GetUser(),
					(string)values[1], (string)values[2], (bool)values[3]);
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

		private async void initData()
		{
			var alltodo=await memoHelper.GetAll();
			MemoList=alltodo.ToList();
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

		public DelegateCommand	 AddMemoCommand { get; set; }
		public DelegateCommand<object> ModifyMemoCommand { get; set; }

		private List<Memo> memoList;
		public List<Memo> MemoList
		{
			get { return memoList; }
			set { SetProperty(ref memoList, value); }
		}
	}
}
