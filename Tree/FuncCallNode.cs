using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleC.Tree
{
	using SimpleC.Interpreter;
	public class FuncCallNode : IExprNode
	{
		public enum ParameterMatching
		{
			Match,
			ParameterCountMismatch,
			ParameterTypeMismatch
		}

		public static ParameterMatching ParameterListMatches(List<VarSpecNode> formalParameters, List<IExprNode> actualParameters)
		{
			// TODO: Perform type checking also

			if (formalParameters.Count != actualParameters.Count)
				return ParameterMatching.ParameterCountMismatch;
			return ParameterMatching.Match;
		}

		public FuncDeclNode Function;
		public List<IExprNode> Parameters;

		//IExprNode members
		public Int32 IntValue { get { return intValue_; } }

		// ISCNode members
		public void Evaluate(Scope scope)
		{
			// Predefined functinos
			if (Function.Name == "println")
			{
				foreach (IExprNode expr in Parameters)
				{
					expr.Evaluate(scope);
					Console.WriteLine(expr.IntValue);
				}
				return;
			}

			Scope globalScope = scope.GlobalScope;
			if (!globalScope.FuncDefs.Contains(Function))
				throw new InterpreterException("Call to undefined function: " + Function.Name);

			Scope childScope = new Scope(globalScope);
			FuncDefNode funcDef = globalScope.FuncDefs.Get(Function);
			for (int i = 0; i < Parameters.Count; ++i)
			{
				Parameters[i].Evaluate(scope);
				childScope.Add(funcDef.Parameters[i].Name, new IntVariable(Parameters[i].IntValue));
			}
			funcDef.Body.Evaluate(childScope);
		}

		public void Print(string indent)
		{
			Console.WriteLine(indent + "FUNC_CALL_NODE");
			Console.WriteLine(indent + "\t" + "Name: " + (Function == null ? "<no function>" : Function.Name));
			Console.WriteLine(indent + "\t" + "PARAMETERS");
			if (Parameters.Count == 0)
				Console.WriteLine(indent + "\t\t" + "<no parameters>");
			else
				foreach (IExprNode expr in Parameters)
					expr.Print(indent + "\t\t");
		}

		protected Int32 intValue_;
	}
}
