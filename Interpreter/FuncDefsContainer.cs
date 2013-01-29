using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleC.Interpreter
{
	using SimpleC.Tree;
	public class FuncDefsContainer
	{
		public bool Contains(FuncDefNode funcDef)
		{
			foreach (FuncDefNode def in definitions_)
				if (def.Equatable.Equals(funcDef.Equatable))
					return true;
			return false;
		}

		public bool Contains(FuncDeclNode funcDecl)
		{
			foreach (FuncDefNode def in definitions_)
				if (def.Equatable.Equals(funcDecl.Equatable))
					return true;
			return false;
		}

		public FuncDefNode Get(FuncDeclNode funcDecl)
		{
			foreach (FuncDefNode def in definitions_)
				if (def.Equatable.Equals(funcDecl.Equatable))
					return def;
			return null;
		}

		public void Add(FuncDefNode funcDef)
		{
			definitions_.Add(funcDef);
		}

		public void Clear()
		{
			definitions_.Clear();
		}

		protected List<FuncDefNode> definitions_ = new List<FuncDefNode>();
	}
}
