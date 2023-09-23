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
	public class AddMemoDialogModel : BindableBase, IDialogAware
	{


        public AddMemoDialogModel()
        {

			RequestCloseCommand = new DelegateCommand(() => {
				RequestClose?.Invoke(new DialogResult(ButtonResult.Cancel)) ;
			});
			SubmitCommand = new DelegateCommand( () => {
				//var memoHelper = new MemoHelper();
				var newmemo = new Models.Memo(OldMemoId,UserManage.GetUser(),
				  MemoTitle, Content, false);
				//await memoHelper.Add(newmemo);
				var key = new DialogParameters();
				key.Add("AddMemoResult",newmemo);
				RequestClose?.Invoke(new DialogResult(ButtonResult.OK, key));
			});
		}

        public string Title => "";
		private Guid OldMemoId;
		public event Action<IDialogResult> RequestClose;

		#region 
		private string memoTitle;
		public string MemoTitle
		{
			get { return memoTitle; }
			set { SetProperty(ref memoTitle, value); }
		}
		private string content;
		public string Content
		{
			get { return content; }
			set { SetProperty(ref content, value); }
		}


		public DelegateCommand RequestCloseCommand { get; set; }	
		public DelegateCommand SubmitCommand { get; set; }
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
			var oldMemo = parameters.GetValue<Memo>("oldMemo");
			if (oldMemo != null)
			{
				
				MemoTitle = oldMemo.Title;
				Content = oldMemo.Content == null ? "" : oldMemo.Content;
				OldMemoId = oldMemo.Id;
			}
		}
	}
}
