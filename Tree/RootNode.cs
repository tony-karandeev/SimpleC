using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleC.Tree
{
	using SimpleC.Interpreter;
	public class RootNode : ISCNode
	{
		public List<ISCNode> Children { get; set; }

		public RootNode()
		{
			Children = new List<ISCNode>();
		}

		public void Print()
		{
			Print("");
		}

		// ISCNode members

		public void Evaluate(Scope parentScope)
		{
			// TODO: evaluate root node
		}

		public void Print(string indent)
		{
			Console.WriteLine(indent + "ROOT_NODE");
			if (Children.Count == 0)
			{
				Console.WriteLine(indent + "\t" + "<no children>");
			}
			else
			{
				foreach (ISCNode child in Children)
					if (child != null)
						child.Print(indent + "\t");
					else
						Console.WriteLine(indent + "\t" + "<null>");
			}
		}
	}
}
