using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Framework.Commands
{
	public interface ICommandDescription
	{
		string Description { get; }
		string Name { get; }
		bool BasicAllowed { get; }
	}
}
