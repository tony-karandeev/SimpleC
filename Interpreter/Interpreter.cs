using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleC.Interpreter
{
	using SimpleC.Tree;
	public class Interpreter
	{
		public Interpreter()
		{
		}

		public static Interpreter Shared 
		{
			get
			{
				if (sharedInstance_ == null)
					sharedInstance_ = new Interpreter();
				return sharedInstance_;
			}
			set
			{
				sharedInstance_ = value;
			}
		}

		public void Prepare(RootNode tree)
		{
			funcDefinitions_.Clear();

			foreach (ISCNode node in tree.Children)
			{
				if (node is VarDefNode)
				{
					globalScope_.Add(node as VarDefNode);
				}
				else if (node is FuncDefNode)
				{
					FuncDefNode funcDef = node as FuncDefNode;
					if (funcDefinitions_.Contains(funcDef))
						throw new InterpreterException("Multiple function definitions for function: " + funcDef.Name);
					funcDefinitions_.Add(funcDef);

					if (funcDef.Name == "main")
						mainFuncDef_ = funcDef;
				}
				else if (node is FuncDeclNode)
				{
					// Just ignore function declarations
				}
			}
			if (mainFuncDef_ == null)
				throw new InterpreterException("Missing 'main' function");
			globalScope_.FuncDefs = funcDefinitions_;
		}

		public void Run()
		{
			Scope scope = new Scope(globalScope_);
			mainFuncDef_.Body.Evaluate(scope);
		}

		protected FuncDefNode mainFuncDef_;
		protected Scope globalScope_ = new Scope(null);
		protected FuncDefsContainer funcDefinitions_ = new FuncDefsContainer();
		
		private static Interpreter sharedInstance_;
	}
}
