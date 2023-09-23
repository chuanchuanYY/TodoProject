using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTodo.Wpf.Models
{
	public record Memo(Guid Id, User User, string Title, string? Content, bool IsCompleted)
	{

	}
}
