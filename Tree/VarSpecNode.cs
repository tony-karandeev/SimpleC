using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleC.Tree
{
	class VarSpecNode :ISCNode
	{
		public TypeSpecNode TypeSpec { get; set; }
		public string Name { get; set; }

		public void Print(string indent)
		{
			Console.WriteLine(indent + "VAR_SPEC");
			Console.WriteLine(indent + "\t" + Name);
			TypeSpec.Print(indent + "\t");
		}
	}
}
