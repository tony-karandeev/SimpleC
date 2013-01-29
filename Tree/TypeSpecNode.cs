using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleC.Tree
{
	using SimpleC.Interpreter;
	public class TypeSpecNode : ISCNode
	{
		public string PrimaryTypeName { get; set; }

		// ISCNode members
		public void Evaluate(Scope parentScope)
		{
			// Nothing to do here
		}

		public void Print(string indent)
		{
			Console.WriteLine(indent + "TYPE_SPEC_NODE");
			Console.WriteLine(indent + "\t" + PrimaryTypeName);
		}
	}
}
