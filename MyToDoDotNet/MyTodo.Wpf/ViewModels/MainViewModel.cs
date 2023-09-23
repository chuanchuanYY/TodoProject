using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTodo.Wpf.ViewModels
{
    class MainViewModel:BindableBase
    {
		private readonly IRegionManager regionManager;

		public MainViewModel(IRegionManager regionManager)
        {
			this.regionManager = regionManager;


			initCommand();
		}

		private void initCommand()
		{
			NavCommand = new DelegateCommand<string>(arg => {
				regionManager.Regions["MainRegion"].RequestNavigate(arg);
			});
		}

		/// <summary>
		/// 导航命令 左边侧边栏导航
		/// </summary>
		public DelegateCommand<string > NavCommand { get; set; }
    }
}
