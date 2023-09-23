using MyToDo.WebAPI.Entitys;

namespace MyToDo.WebAPI.Services
{
	public interface ITodoService
	{
		Task<APIRespons> Add(TodoDto todo);
		Task<APIRespons> Delete(Guid todoId);
		Task<APIRespons> Update(TodoDto todo);
		Task<APIRespons> GetAll(UserDto userDto);
	}

	public record TodoDto(Guid Id,UserDto User,string Title,string? Content,bool IsCompleted);
}
