using Microsoft.EntityFrameworkCore;
using MyToDo.WebAPI.Entitys;
using MyToDo.WebAPI.Services;

namespace MyToDo.WebAPI
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.

			builder.Services.AddControllers();
			// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
			builder.Services.AddEndpointsApiExplorer();
			builder.Services.AddSwaggerGen();
			
			//×¢²á·þÎñ  Register Services
			builder.Services.AddDbContext<MyDbContext>(option => {
				var str = builder.Configuration.GetSection("DbConnectStr").Value;
				option.UseSqlServer(str);
			});
			builder.Services.AddScoped<IUserService, UserService>();
			builder.Services.AddScoped<ITodoService, TodoService>();
			builder.Services.AddScoped<IMemoService, MemoService>();

			var app = builder.Build();
			
			// Configure the HTTP request pipeline.
			if (app.Environment.IsDevelopment())
			{
				app.UseSwagger();
				app.UseSwaggerUI();
			}

			app.UseHttpsRedirection();

			app.UseAuthorization();


			app.MapControllers();

			app.Run();
		}
	}
}