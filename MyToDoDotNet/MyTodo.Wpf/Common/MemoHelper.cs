using MyTodo.Common;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyTodo.Wpf.Models;

namespace MyTodo.Wpf.Common
{
	public class MemoHelper
	{
		private string BaseUri = "https://localhost:7027/api/Memo";
		private HttpHelper httpHelper;
        public MemoHelper()
        {
			httpHelper=new HttpHelper();
			httpHelper.Token = UserManage.Token;
		}
        public async Task<IEnumerable<Memo>> GetAll()
		{
			
			var respons = await httpHelper.Get($"{BaseUri}/GetAllByUser?userName=admin&Password=123456");
			if (respons == null) return null;
			var jobj = JObject.Parse(respons);
			var todos = jobj.SelectToken("content")!
				.ToList()
				.Select(t => JsonConvert.DeserializeObject<Memo>(t.ToString()));
			return todos;
		}


		public async Task Add(Memo memo)
		{
			string uri = $"{BaseUri}/Add";
			await httpHelper.Post(uri, memo);
		}

		public async Task Update(Memo memo)
		{
			string uri = $"{BaseUri}/Update";
			await httpHelper.Post(uri, memo);
		}
	}
}
