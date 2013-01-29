using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleC.Tree
{
	using SimpleC.Interpreter;
	public class CompoundStatementNode : ISCNode
	{
		public CompoundStatementNode()
		{
			Statements = new List<ISCNode>();
		}

		public List<ISCNode> Statements { get; set; }

		// ISCNode members
		public void Evaluate(Scope scope)
		{
			foreach (ISCNode statement in Statements)
			{
				if (statement is CompoundStatementNode)
				{
					Scope childScope = new Scope(scope);
					statement.Evaluate(childScope);
				}
				else if (statement is IExprNode)
				{
					statement.Evaluate(scope);
				}
				else if (statement is VarDefNode)
				{
					scope.Add(statement as VarDefNode);
				}
			}

			// TODO: Evaluate compound statement
		}

		public void Print(string indent)
		{
			Console.WriteLine(indent + "COMPOUND_STATEMENT_NODE");
			foreach (ISCNode node in Statements)
				node.Print(indent + "\t");
		}
	}
}
