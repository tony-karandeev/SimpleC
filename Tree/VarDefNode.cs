using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleC.Tree
{
	using SimpleC.Interpreter;
	public class VarDefNode : ISCNode
	{
		public VarDefNode(VarSpecNode varSpec)
		{
			VarSpec = varSpec;
		}

		public VarSpecNode VarSpec { get; set; }

		// ISCNode members
		public void Evaluate(Scope parentScope)
		{
		}

		public void Print(string indent)
		{
			Console.WriteLine(indent + "VAR_DEF_NODE");
			VarSpec.Print(indent + "\t");
		}
	}
}
