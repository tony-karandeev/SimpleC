using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleC.Tree
{
	public interface IExprNode : ISCNode
	{
		Int32 IntValue { get; }
	}
}
