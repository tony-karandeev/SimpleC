using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleC.Tree
{
	public class VarDefNode : ISCNode
	{
		public VarSpecNode VarSpec { get; set; }
	
		// ISCNode member
		public void Print(string indent)
		{
			Console.WriteLine(indent + "VAR_DEF");
			VarSpec.Print(indent + "\t");
		}
	}
}
