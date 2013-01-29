using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleC.Tree
{
	public class FuncDefNode : FuncDeclNode
	{
		public FuncDefNode()
		{
			Body = new CompoundStatementNode(); // An empty statement
		}

		public CompoundStatementNode Body { get; set; }

		public override void Print(string indent)
		{
			Console.WriteLine(indent + "FUNC_DEF_NODE");
			ReturnTypeSpec.Print(indent + "\t");
			Console.WriteLine(indent + "\t" + "Name: " + Name);
			Console.WriteLine(indent + "\t" + "PARAMETERS");
			if (Parameters.Count == 0)
				Console.WriteLine(indent + "\t\t" + "<no parameters>");
			else
				foreach (VarSpecNode varSpec in Parameters)
					varSpec.Print(indent + "\t\t");

			Console.WriteLine(indent + "\t" + "FUNC_BODY");
			if (Body.Statements.Count == 0)
				Console.WriteLine(indent + "\t\t" + "<empty body>");
			else
				foreach (ISCNode statement in Body.Statements)
					statement.Print(indent + "\t\t");
		}
	}
}
