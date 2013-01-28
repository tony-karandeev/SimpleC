using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleC.Tree
{
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

		// ISCNode
		public void Print(string indent)
		{
			Console.WriteLine(indent + "ROOT");
			foreach (ISCNode child in Children)
				if (child != null)
					child.Print(indent + "\t");
		}
	}
}
