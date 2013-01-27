using System;
using System.Collections.Generic;
using System.Text;

using Antlr.Runtime;

namespace SimpleC
{
	class IdentAstNode : AstNode
	{
		public IdentAstNode(IToken token)
			: base(token)
		{
		}

		public IdentAstNode(int tokenType, string name)
			: base(new CommonToken(tokenType))
		{
			Name = name;
		}

		public string Name { get; set; }

		public override string ToString()
		{
			return Name;
		}
	}
}
