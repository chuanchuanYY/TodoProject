using MyToDo.WebAPI.Services;

namespace MyToDo.WebAPI.Common
{
	public static class APIResponsHelper
	{

		public static APIRespons CreateOK(object? content=null,string? msg=null)
		{
			return new APIRespons(content,msg);
		}
		public static APIRespons CreateFail(object? content=null, string? msg=null)
		{
			return new APIRespons(content, msg,false);
		}

		public static APIRespons CreateOkWithToken(string token,object? content = null, string? msg = null)
		{
			var res=new APIRespons(content, msg);
			res.Token= token;
			return res;
		}
	}
}
