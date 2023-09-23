namespace MyToDo.WebAPI.Services
{
	public interface IUserService
	{
		Task<APIRespons> Add(UserDto user);
		Task<APIRespons> Login(UserDto user);
	}

   public record UserDto(string UserName,string Password);
}
