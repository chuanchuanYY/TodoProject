using MyTodo.Common;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyTodo.Wpf.Models;
using System.Text.Json.Serialization.Metadata;

namespace MyTodo.Wpf.Common
{
	public class TodoHelper
	{
        public TodoHelper()
        {
			_httpHelper = new HttpHelper();
		}
        private HttpHelper _httpHelper;
		private string BaseUri = "https://localhost:7027";
		public async Task<IEnumerable<Todo>> GetAll()
		{
			var respons = await _httpHelper.Get($"{BaseUri}/api/Todo/GetAllByUser?userName=admin&Password=123456");
			if (respons == null) return null;
			var jobj = JObject.Parse(respons);
			var todos = jobj.SelectToken("content")!
				.ToList()
				.Select(t => JsonConvert.DeserializeObject<Todo>(t.ToString()));
			return todos;
		}

		public async Task Add(Todo todo)
		{
			string uri = $"{BaseUri}/api/Todo/Add";
		    await _httpHelper.Post(uri,todo);
		}

		public async Task Update(Todo todo)
		{
			string uri = $"{BaseUri}/api/Todo/Update";
			await _httpHelper.Post(uri, todo);
		}
	}
}
