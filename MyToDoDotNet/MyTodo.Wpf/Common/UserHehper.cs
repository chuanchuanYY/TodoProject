using MyTodo.Common;
using MyTodo.Wpf.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTodo.Wpf.Common
{
	public class UserHehper
	{
		private HttpHelper httpHelper;
		public UserHehper() {
			httpHelper=new HttpHelper();
		}
		private string BaseUri = "https://localhost:7027/api/User";

		public async Task<User> Login(User user)
		{
		    var respons= await	httpHelper.Post($"{BaseUri}/Login",user);
			if (respons == null) return null;
			var jobj=JObject.Parse(respons);
			if (!((bool)jobj.GetValue("isSuccess")!))
			{
				return null;
			}
			UserManage.Token = jobj.GetValue("token")?.ToString();
			return user;
		}

		/// <summary>
		/// 注册
		/// </summary>
		/// <param name="user"></param>
		/// <returns></returns>
		public async Task<User> Register(User user)
		{
			var respons = await httpHelper.Post($"{BaseUri}/Register", user);
			if (respons == null) return null;
			var jobj = JObject.Parse(respons);
			if (!((bool)jobj.GetValue("isSuccess")!))
			{
				return null;
			}
			return user;
		}
	}
}
