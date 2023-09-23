namespace MyToDo.WebAPI.Entitys
{
	public class User
	{
		public Guid Id { get; set; }
		/// <summary>
		/// 用户名
		/// </summary>
        public string UserName { get; set; }	
		/// <summary>
		/// 密码
		/// </summary>
		public string Password { get; set; }
		/// <summary>
		/// 软删除
		/// </summary>
		public bool IsDelete { get; set; } = false;

		/// <summary>
		/// 代办事项集合
		/// </summary>
		public List<ToDo> ToDos { get; set; } = new List<ToDo>();
		/// <summary>
		/// 备忘录集合
		/// </summary>
        public List<Memo> Memos { get; set; } = new List<Memo>();
    }
}
