using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleC.Interpreter
{
	using SimpleC.Tree;
	public class Scope
	{
		public FuncDefsContainer FuncDefs { get; set; }

		public Scope(Scope parent = null)
		{
			Parent = parent;
		}

		public Scope Parent { get; set; }
		public Scope GlobalScope
		{
			get
			{
				Scope scope = this;
				while (scope.Parent != null)
					scope = scope.Parent;
				return scope;
			}
		}

		public bool IsDefined(string name)
		{
			if (IsDefinedHere(name))
				return true;
			if (Parent != null)
				return Parent.IsDefined(name);
			return false;
		}

		public bool IsDefined(FuncDeclNode funcDecl)
		{
			if (FuncDefs == null)
				return false;
			return FuncDefs.Contains(funcDecl);
		}

		public void Add(VarDefNode varDef)
		{
			string varName = varDef.VarSpec.Name;
			if (IsDefinedHere(varName))
				throw new InterpreterException("Multiple definitions within the same scope for variable: " + varName);
			Variables[varName] = new IntVariable(varDef);
		}

		public void Add(VarSpecNode varSpec)
		{
			Add(new VarDefNode(varSpec));
		}

		public void Add(string varName, IntVariable var)
		{
			if (IsDefinedHere(varName))
				throw new InterpreterException("Multiple definitions within the same scope for variable: " + varName);
			Variables[varName] = var;
		}

		public IntVariable Get(string name)
		{
			if (IsDefinedHere(name))
				return Variables[name];
			if (Parent != null)
				return Parent.Get(name);
			return null;
		}

		protected bool IsDefinedHere(string name)
		{
			return Variables.ContainsKey(name);
		}

		protected Dictionary<string, IntVariable> Variables { get { return variables_; } }

		protected Dictionary<string, IntVariable> variables_ = new Dictionary<string, IntVariable>();
	}
}
