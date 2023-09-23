using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyToDo.WebAPI.Services;

namespace MyToDo.WebAPI.Controllers
{
	[Route("api/[controller]/[action]")]
	[ApiController]
	public class MemoController : ControllerBase
	{
		private readonly IMemoService memoService;

		public MemoController(IMemoService memoService)
        {
			this.memoService = memoService;
		}

		[HttpPost]
		public async Task<ActionResult<APIRespons>> Add([FromBody] MemoDto memo)
		{
			if (memo.User == null || memo.Title == null)
			{
				return BadRequest();
			}
			return await memoService.Add(memo);
		}

		[HttpGet]
		public async Task<ActionResult<APIRespons>> Delete(Guid memoId)
		{
			return await memoService.Delete(memoId);
		}

		[HttpPost]
		public async Task<ActionResult<APIRespons>> Update([FromBody] MemoDto memo)
		{
			if (memo == null)
			{
				return BadRequest();
			}
			return await memoService.Update(memo);
		}


		[HttpGet]
		public async Task<ActionResult<APIRespons>> GetAllByUser(string userName,string password)
		{
			if (userName == null||password ==null)
			{
				return BadRequest();
			}
			var user=new UserDto(userName,password);
			return await memoService.GetAll(user);
		}
	}

}
