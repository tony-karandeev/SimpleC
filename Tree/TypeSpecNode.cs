using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleC.Tree
{
	public class TypeSpecNode : ISCNode
	{
		public string PrimaryTypeName { get; set; }

		// ISCNode
		public void Print(string indent)
		{
			Console.WriteLine(indent + "TYPE_SPEC");
			Console.WriteLine(indent + "\t" + PrimaryTypeName);
		}
	}
}
