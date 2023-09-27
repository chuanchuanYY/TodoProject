using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using MyToDo.WebAPI.Entitys;
using MyToDo.WebAPI.Services;
using System.Text;

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
			builder.Services.AddCors(option=> {

				option.AddDefaultPolicy(opt => {
					opt.AllowAnyOrigin()
					   .AllowAnyMethod()
					   .AllowAnyHeader();
				});
			});
			
			builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
				.AddJwtBearer(conf => {
					var keybyts = Encoding.UTF8.GetBytes(builder.Configuration.GetSection("JwtKey").Value!.ToString()!);
					var secKey = new SymmetricSecurityKey(keybyts);
					conf.TokenValidationParameters = new()
					{
						ValidateIssuer = false,
						ValidateAudience = false,
						ValidateLifetime = false,
						ValidateIssuerSigningKey = true,
						IssuerSigningKey = secKey
					};
				});
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
			app.UseCors();
			app.UseAuthentication();
			app.UseAuthorization();

			app.MapControllers();

			app.Run();
		}
	}
}