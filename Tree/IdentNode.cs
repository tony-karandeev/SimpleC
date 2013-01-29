using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleC.Tree
{
	using SimpleC.Interpreter;
	public class IdentNode : IExprNode
	{
		public string Name { get; set; }

		public Int32 IntValue { get { return intValue_; } }

		// ISCNode members
		public void Evaluate(Scope scope)
		{
			if (!scope.IsDefined(Name))
				throw new InterpreterException("Undefined variable: " + Name);
			intValue_ = scope.Get(Name).Value;
		}

		public void Print(string indent)
		{
			Console.WriteLine(indent + Name);
		}

		protected Int32 intValue_;
	}
}
