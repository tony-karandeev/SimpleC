using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleC.Tree
{
	using SimpleC.Interpreter;
	public interface ISCNode
	{
		void Evaluate(Scope parentScope);
		void Print(string indent);
	}
}
