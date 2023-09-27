using MyTodo.Wpf.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MyTodo.Wpf.Common
{
	public static class UserManage
	{
		private static User User;
		public static void SetUser(User user)
		{
			User = user;
		}
		public static User GetUser()
		{
			return User;
		}
		public static string? Token { get; set; }
	}
}
