using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyToDo.WebAPI.Services;
using System.Text.RegularExpressions;

namespace MyToDo.WebAPI.Controllers
{
	[Route("api/[controller]/[action]")]
	[ApiController]
	public class UserController : ControllerBase
	{
		private readonly IUserService userService;

		public UserController(IUserService userService)
		{
			this.userService = userService;
		}


		[HttpPost]
		public async Task<ActionResult<APIRespons>> Register(UserDto user)
		{
			if (user.UserName == null || user.UserName == ""
				|| user.Password == null || user.Password == "")
			{
				return BadRequest();
			}
			//密码可以是英文和数字  ，密码长度不能大于20
			var matchResult = Regex.Match(user.Password, "^[A-Za-z0-9]+$");
			if (!matchResult.Success || user.Password.Length > 20)
			{
				return BadRequest();
			}
			return await userService.Add(user);
		}
		[HttpPost]
		public async Task<ActionResult<APIRespons>> Login(UserDto user)
		{
			if (user.UserName == null || user.UserName == ""
				|| user.Password == null || user.Password == "")
			{
				return BadRequest();
			}
			return await userService.Login(user);
		}
		
    }
}
