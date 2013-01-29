using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleC.Interpreter
{
	using SimpleC.Tree;
	public class IntVariable
	{
		public IntVariable(VarDefNode varDef)
		{
			Value = 0;
		}

		public IntVariable(Int32 value)
		{
			Value = value;
		}

		public Int32 Value { get; set; }
	}
}
