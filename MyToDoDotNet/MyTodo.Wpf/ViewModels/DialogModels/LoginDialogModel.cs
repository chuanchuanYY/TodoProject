using MyTodo.Wpf.Common;
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
	public class LoginDialogModel : BindableBase, IDialogAware
	{
        public LoginDialogModel()
        {


			CloseCommand = new DelegateCommand(() => {
				RequestClose?.Invoke(new DialogResult(ButtonResult.No));
			});
			LoginCommand = new DelegateCommand<object>(async (arg) => {
				var values = arg as object[];
				var userHelper = new UserHehper();
			    var user=await userHelper.Login(new Models.User((string)values[0],
				   (string)values[1]));
				if (user != null)
				{
					UserManage.SetUser(user);
					RequestClose?.Invoke(new DialogResult(ButtonResult.OK));
				}
			});
		}
        public string Title => "";

		public event Action<IDialogResult> RequestClose;
		public DelegateCommand CloseCommand { get; set; }
		public DelegateCommand<object> LoginCommand { get; set; }	
		
		public bool CanCloseDialog()
		{
			return true;
		}

		public void OnDialogClosed()
		{
			
		}

		public void OnDialogOpened(IDialogParameters parameters)
		{
			
		}
	}
}
