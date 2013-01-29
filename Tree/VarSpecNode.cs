using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleC.Tree
{
	using SimpleC.Interpreter;
	public class VarSpecNode : ISCNode
	{
		public TypeSpecNode TypeSpec { get; set; }
		public string Name { get; set; }

		public void Evaluate(Scope parentScope)
		{
			// Nothing to do here
		}

		public void Print(string indent)
		{
			Console.WriteLine(indent + "VAR_SPEC_NODE");
			TypeSpec.Print(indent + "\t");
			Console.WriteLine(indent + "\t" + "Name: " + Name);
		}
	}
}
