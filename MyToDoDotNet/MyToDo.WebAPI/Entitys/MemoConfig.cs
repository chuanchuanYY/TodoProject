using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MyToDo.WebAPI.Entitys
{
	public class MemoConfig : IEntityTypeConfiguration<Memo>
	{
		public void Configure(EntityTypeBuilder<Memo> builder)
		{
			builder.HasKey(x => x.Id);
			builder.HasOne<User>(m => m.User).WithMany(u=>u.Memos);
		}
	}
}
