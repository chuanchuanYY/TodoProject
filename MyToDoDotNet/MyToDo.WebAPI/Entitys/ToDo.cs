namespace MyToDo.WebAPI.Entitys
{
	public class ToDo
	{
        public long Id { get; set; }
        /// <summary>
        /// 逻辑主键
        /// </summary>
		public Guid ToDoId { get; set; }

        /// <summary>
        /// 用户外键 表示属于哪个用户
        /// </summary>
        public User User { get; set; }
        /// <summary>
        /// 代办事项标题 （概述）
        /// </summary>
        public string  Title { get; set; }
        /// <summary>
        /// 内容
        /// </summary>
        public string? Content { get; set; }
        /// <summary>
        /// 是否完成
        /// </summary>
        public bool IsCompleted { get; set; }
    }
}
