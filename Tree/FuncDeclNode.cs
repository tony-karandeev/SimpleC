using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleC.Tree
{
	using SimpleC.Interpreter;
	public class FuncDeclNode : ISCNode
	{
		public FuncDeclNode()
		{
			Parameters = new List<VarSpecNode>();
		}

		public TypeSpecNode ReturnTypeSpec { get; set; }
		public string Name { get; set; }
		public List<VarSpecNode> Parameters { get; set; }

		public FuncDeclEquatable Equatable { get { return new FuncDeclEquatable(Name); } }

		public virtual void Evaluate(Scope parentScope)
		{
			// Nothing to do here
		}
		
		public virtual void Print(string indent)
		{
			Console.WriteLine(indent + "FUNC_DECL_NODE");
			ReturnTypeSpec.Print(indent + "\t");
			Console.WriteLine(indent + "\t" + "Name: " + Name);
			Console.WriteLine(indent + "\t" + "PARAMETERS");
			if (Parameters.Count == 0)
				Console.WriteLine(indent + "\t\t" + "<no parameters>");
			else
				foreach (VarSpecNode varSpec in Parameters)
					varSpec.Print(indent + "\t\t");
		}
	}
}
