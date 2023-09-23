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
	}
}
