namespace MyToDo.WebAPI.Services
{
	/// <summary>
	/// 统一API接口的返回值
	/// </summary>
	public class APIRespons
	{
		public APIRespons() { }
        public APIRespons(object? content=null,string? msg=null,bool isSuccess=true)
        {
				this.Content = content;
				this.IsSuccess = isSuccess;
				this.Message = msg;	
        }
        public bool IsSuccess { get; set; }
		public string? Message { get; set; }
        public object? Content { get; set; }
		public string? Token { get; set; }
    }
}
