using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MyToDo.WebAPI.Entitys
{
	public class ToDoConfig : IEntityTypeConfiguration<ToDo>
	{
		public void Configure(EntityTypeBuilder<ToDo> builder)
		{
			builder.HasKey(x => x.Id);
			builder.HasOne<User>(t => t.User).WithMany(u => u.ToDos);
		}
	}
}
