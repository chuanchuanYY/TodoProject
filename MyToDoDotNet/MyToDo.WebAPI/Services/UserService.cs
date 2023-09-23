using Microsoft.EntityFrameworkCore;
using MyToDo.WebAPI.Common;
using MyToDo.WebAPI.Entitys;

namespace MyToDo.WebAPI.Services
{
	public class UserService : IUserService
	{
		private readonly MyDbContext dbContext;

		public UserService(MyDbContext dbContext)
        {
			this.dbContext = dbContext;
		}
        public async Task<APIRespons> Add(UserDto user)
		{
			var _user = new User();
			_user.UserName = user.UserName;
			_user.Password = user.Password;
		    await dbContext.Users.AddAsync(_user);
			await dbContext.SaveChangesAsync();
			return APIResponsHelper.CreateOK(user);
		}

		public async Task<APIRespons> Login(UserDto user)
		{
			var _user=await dbContext.Users.FirstOrDefaultAsync(u=>u.UserName.Equals(user.UserName)
			&& u.Password.Equals(user.Password));
			if (_user == null)
			{
				return APIResponsHelper.CreateFail(null,"账号或密码错误");
			}
			return APIResponsHelper.CreateOK(user,"登录成功");
		}
	}
}
