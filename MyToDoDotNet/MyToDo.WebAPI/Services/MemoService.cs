using Microsoft.EntityFrameworkCore;
using MyToDo.WebAPI.Common;
using MyToDo.WebAPI.Entitys;

namespace MyToDo.WebAPI.Services
{
	public class MemoService : IMemoService
	{
		private readonly MyDbContext dbContext;

		public MemoService(MyDbContext dbContext)
        {
			this.dbContext = dbContext;
		}

		/// <summary>
		/// 把数据传输模型转换为数据库实体模型
		/// </summary>
		/// <param name="todo"></param>
		/// <returns></returns>
		public async Task<Memo> DtoToModel(MemoDto memo)
		{
			var user = await dbContext.Users.FirstOrDefaultAsync(u => u.UserName.Equals(memo.User.UserName)
			&& u.Password.Equals(memo.User.Password));
			if (user == null)
			{
				return null;
			}
			var _memo = new Memo();
			_memo.MemoId = Guid.NewGuid();
			_memo.User = user;
			_memo.Title = memo.Title;
			_memo.Content = memo.Content;
			_memo.IsCompleted = memo.IsCompleted;
			return _memo;
		}
		public async Task<APIRespons> Add(MemoDto memo)
		{
			var _memo = await DtoToModel(memo);
			if (_memo == null)
			{
				return APIResponsHelper.CreateFail();
			}
			await dbContext.Memos.AddAsync(_memo);
			await dbContext.SaveChangesAsync();
			return APIResponsHelper.CreateOK(msg: $"{_memo.Title} 添加成功");
		}

		public async Task<APIRespons> Delete(Guid MemoId)
		{
			var _memo = await dbContext.Memos.FirstOrDefaultAsync(t => t.MemoId.Equals(MemoId));
			if (_memo == null)
			{
				return APIResponsHelper.CreateFail();
			}
			dbContext.Memos.Remove(_memo);
			await dbContext.SaveChangesAsync();
			return APIResponsHelper.CreateOK(msg: $"{_memo.Title} is delete ");
		}

		public async Task<APIRespons> GetAll(UserDto userDto)
		{
			var user = await dbContext.Users.Include(u => u.Memos).FirstOrDefaultAsync(u => u.UserName.Equals(userDto.UserName)
		    && u.Password.Equals(userDto.Password));
			if (user == null)
			{
				return APIResponsHelper.CreateFail();
			}
			var memos = user.Memos.ToList();
			var result = new List<MemoDto>();
			foreach (var memo in memos)
			{
				result.Add(new MemoDto(memo.MemoId,
					new UserDto(memo.User.UserName, memo.User.Password)
					, memo.Title, memo.Content, memo.IsCompleted));
			}
			return APIResponsHelper.CreateOK(result, "success");
		}

		public async Task<APIRespons> Update(MemoDto memo)
		{
			var _memo = await dbContext.Memos.FirstOrDefaultAsync(t => t.MemoId.Equals(memo.Id));
			if (_memo == null)
			{
				return APIResponsHelper.CreateFail();
			}
			_memo.Title = memo.Title;
			_memo.Content = memo.Content;
			_memo.IsCompleted = memo.IsCompleted;
			await dbContext.SaveChangesAsync();
			return APIResponsHelper.CreateOK(msg: "修改成功"); ;
		}
	}
}
