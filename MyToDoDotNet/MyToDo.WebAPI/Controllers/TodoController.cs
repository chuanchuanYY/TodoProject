using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyToDo.WebAPI.Services;
using System.Security.Claims;

namespace MyToDo.WebAPI.Controllers
{
	[Route("api/[controller]/[action]")]
	[ApiController]
	[Authorize]
	public class TodoController : ControllerBase
	{
		private readonly ITodoService todoService;

		public TodoController(ITodoService todoService)
		{
			this.todoService = todoService;
		}

		[HttpPost]
		public async Task<ActionResult<APIRespons>> Add([FromBody] TodoDto todo)
		{
			if (todo.User == null || todo.Title == null)
			{
				return BadRequest();
			}
			return await todoService.Add(todo);
		}

		[HttpGet]
		public async Task<ActionResult<APIRespons>> Delete(Guid todoId)
		{
			 return await todoService.Delete(todoId);
		}

		[HttpPost]
		public async Task<ActionResult<APIRespons>> Update([FromBody] TodoDto todo)
		{
			if (todo == null)
			{
				return BadRequest();
			}
			return await todoService.Update(todo);
		}


		[HttpGet]
		public async Task<ActionResult<APIRespons>> GetAllByUser(string  userName,string Password)
		{
			var t = this.User.FindFirst(ClaimTypes.NameIdentifier)!.Value;
			Console.WriteLine(t);
			if (userName == null||Password==null)
			{
				return BadRequest();
			}
			var user = new UserDto(userName,Password);
			return await todoService.GetAll(user);
		}
    }
}
