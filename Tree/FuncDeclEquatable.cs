using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleC.Tree
{
	public class FuncDeclEquatable : IEquatable<FuncDeclEquatable>
	{
		public FuncDeclEquatable(string funcName)
		{
			FuncName = funcName;
		}

		public string FuncName { get; set; }

		// IEquitable<FuncDeclEquitable>
		public bool Equals(FuncDeclEquatable other)
		{
			return FuncName == other.FuncName;
		}
	}
}
