using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace SimpleC.Tree
{
	using SimpleC.Interpreter;
	using BinaryExpressionType = SimpleC.Grammar.SimpleCParser;
	public class BinaryExprNode : IExprNode
	{
		public BinaryExprNode(int type, IExprNode left, IExprNode right)
		{
			Type = type;
			Left = left;
			Right = right;
		}

		public int Type { get; set; }
		public IExprNode Left { get; set; }
		public IExprNode Right { get; set; }

		public Int32 IntValue { get { return intValue_; } }

		// ISCNode members

		public void Evaluate(Scope scope)
		{
			Debug.Assert(Left != null && Right != null, "Null operand in binary expression");
			Left.Evaluate(scope);
			Right.Evaluate(scope);
			switch (Type)
			{
				case BinaryExpressionType.ADD:
					intValue_ = Left.IntValue + Right.IntValue;
					break;
				case BinaryExpressionType.SUB:
					intValue_ = Left.IntValue - Right.IntValue;
					break;
				case BinaryExpressionType.MUL:
					intValue_ = Left.IntValue * Right.IntValue;
					break;
				case BinaryExpressionType.DIV:
					intValue_ = Left.IntValue / Right.IntValue;
					break;
				case BinaryExpressionType.MOD:
					intValue_ = Left.IntValue % Right.IntValue;
					break;
				case BinaryExpressionType.ASSIGN:
					IdentNode identNode = Left as IdentNode;
					if (identNode == null)
						throw new InterpreterException("Left operand of '=' must be an lvalue");
					if (!scope.IsDefined(identNode.Name))
						throw new InterpreterException("Undefined variable: " + identNode.Name);
					intValue_ = Right.IntValue;
					scope.Get(identNode.Name).Value = intValue_;
					break;
				default:
					throw new InterpreterException("Unexpected expression type");
			}
		}

		public void Print(string indent)
		{
			Console.WriteLine(indent + "BINARY_EXPR_NODE");

			if (Left != null)
				Left.Print(indent + "\t");
			else
				Console.WriteLine(indent + "\t" + "<null>");

			if (Right != null)
				Right.Print(indent + "\t");
			else
				Console.WriteLine(indent + "\t" + "<null>");		
		}
		protected Int32 intValue_;
	}
}
