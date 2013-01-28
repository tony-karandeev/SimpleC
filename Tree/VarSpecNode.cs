using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleC.Tree
{
	public class VarSpecNode : ISCNode
	{
		public TypeSpecNode TypeSpec { get; set; }
		public string Name { get; set; }

		public void Print(string indent)
		{
			Console.WriteLine(indent + "VAR_SPEC");
			Console.WriteLine(indent + "\t" + Name);
			if (TypeSpec == null)
			{
				Console.WriteLine("TypeSpec == NULL");
			}
			else
			{
				TypeSpec.Print(indent + "\t");
			}
		}
	}
}
