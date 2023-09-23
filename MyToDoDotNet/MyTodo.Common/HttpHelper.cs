using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MyTodo.Common
{
	public class HttpHelper
	{
		#region return string
		public async Task<string?> Get(string uri)
		{
			using HttpRequestMessage requestMessage = new HttpRequestMessage();
			requestMessage.Method = HttpMethod.Get;
			requestMessage.RequestUri = new Uri(uri);
		    return await Send(requestMessage);
		}

		public async Task<string?> Post(string uri,object content)
		{
			using HttpRequestMessage requestMessage = new HttpRequestMessage();
			requestMessage.Method = HttpMethod.Post;
			requestMessage.RequestUri = new Uri(uri);
			requestMessage.Content = new StringContent(JsonSerializer.Serialize(content)
				,Encoding.UTF8, "application/json");
			return await Send(requestMessage);
		}

		public async Task<string?> Send(HttpRequestMessage requestMessage)
		{
			using HttpClient httpClient = new HttpClient();
			var response=await httpClient.SendAsync(requestMessage);
			if (response.IsSuccessStatusCode)
			{
				return await response.Content.ReadAsStringAsync();
			}
			return null;
		}
		#endregion
	}
}
