using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleC.Tree
{
	using SimpleC.Interpreter;
	public class IntegerNode : IExprNode
	{
		public IntegerNode(string stringValue)
		{
			intValue_ = Int32.Parse(stringValue);
		}

		public Int32 IntValue { get { return intValue_; } }

		public void Evaluate(Scope parentScope)
		{
			// Really nothing to do here
		}

		public void Print(string indent)
		{
			Console.WriteLine(indent + IntValue.ToString());
		}

		protected Int32 intValue_;
	}
}
