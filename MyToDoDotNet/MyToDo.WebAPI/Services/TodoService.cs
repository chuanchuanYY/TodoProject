using Microsoft.EntityFrameworkCore;
using MyToDo.WebAPI.Common;
using MyToDo.WebAPI.Entitys;

namespace MyToDo.WebAPI.Services
{
	public class TodoService : ITodoService
	{
		private readonly MyDbContext dbContext;

		public TodoService(MyDbContext dbContext)
        {
			this.dbContext = dbContext;
		}
		/// <summary>
		/// 把数据传输模型转换为数据库实体模型
		/// </summary>
		/// <param name="todo"></param>
		/// <returns></returns>
		public async Task<ToDo> DtoToModel(TodoDto todo)
		{
			var user = await dbContext.Users.FirstOrDefaultAsync(u => u.UserName.Equals(todo.User.UserName)
		    && u.Password.Equals(todo.User.Password));
			if (user == null)
			{
				return null;
			}
			var _todo = new ToDo();
			_todo.ToDoId = Guid.NewGuid();
			_todo.User = user;
			_todo.Title = todo.Title;
			_todo.Content = todo.Content;
			_todo.IsCompleted = todo.IsCompleted;
			return _todo;
		}
        public async Task<APIRespons> Add(TodoDto todo)
		{
			//var user=await dbContext.Users.FirstOrDefaultAsync(u=>u.UserName.Equals(todo.User.UserName)
			//&&u.Password.Equals(todo.User.Password));
			//if (user == null)
			//{
			//	return APIResponsHelper.CreateFail();
			//}
			//var _todo = new ToDo();
			//_todo.ToDoId=Guid.NewGuid();
			//_todo.User = user;
			//_todo.Title = todo.Title;
			//_todo.Content = todo.Content;
			//_todo.IsCompleted = todo.IsCompleted;
			var _todo=await  DtoToModel(todo);
			if (_todo == null)
			{
				return APIResponsHelper.CreateFail();
			}
			await dbContext.ToDos.AddAsync(_todo);
			await dbContext.SaveChangesAsync();
			return APIResponsHelper.CreateOK(msg:$"{todo.Title} 添加成功");
		}

		public async Task<APIRespons> Delete(Guid todoId)
		{
			var _todo=await dbContext.ToDos.FirstOrDefaultAsync(t=>t.ToDoId.Equals(todoId));
			if (_todo == null)
			{
				return APIResponsHelper.CreateFail();
			}
			dbContext.ToDos.Remove(_todo);
			await dbContext.SaveChangesAsync();
			return APIResponsHelper.CreateOK(msg:$"{_todo.Title} is delete ");
		}

		public async Task<APIRespons> GetAll(UserDto userDto)
		{
			var user = await dbContext.Users.Include(u=>u.ToDos).FirstOrDefaultAsync(u => u.UserName.Equals(userDto.UserName)
			&& u.Password.Equals(userDto.Password));
			if (user == null)
			{
				return APIResponsHelper.CreateFail();
			}
			var todos=user.ToDos.ToList();
			var result = new List<TodoDto>();
			foreach (var todo in todos)
			{
				result.Add(new TodoDto(todo.ToDoId,
					new UserDto(todo.User.UserName,todo.User.Password)
					,todo.Title,todo.Content,todo.IsCompleted));
			}
			return APIResponsHelper.CreateOK(result, "success");
		}

		public async Task<APIRespons> Update(TodoDto todo)
		{
			var _todo=await dbContext.ToDos.FirstOrDefaultAsync(t=>t.ToDoId.Equals(todo.Id));
			if (_todo == null)
			{
				return APIResponsHelper.CreateFail();
			}
			_todo.Title = todo.Title;
			_todo.Content= todo.Content;	
			_todo.IsCompleted= todo.IsCompleted;
			await dbContext.SaveChangesAsync();
			return APIResponsHelper.CreateOK(msg:"修改成功");;
		}
	}
}
