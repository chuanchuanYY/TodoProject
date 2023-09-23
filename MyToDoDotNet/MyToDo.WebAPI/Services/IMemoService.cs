namespace MyToDo.WebAPI.Services
{
	public interface IMemoService
	{
		Task<APIRespons> Add(MemoDto memo);
		Task<APIRespons> Delete(Guid MemoId);
		Task<APIRespons> Update(MemoDto memo);
		Task<APIRespons> GetAll(UserDto userDto);
	}

	public record MemoDto(Guid Id, UserDto User, string Title, string? Content, bool IsCompleted);
}
