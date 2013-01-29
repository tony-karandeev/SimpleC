using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace SimpleC.Tree
{
	public class FuncDeclsContainer
	{
		public bool Contains(FuncDeclEquatable funcDeclEquatable)
		{
			foreach (FuncDeclNode decl in declarations_)
				if (decl.Equatable.Equals(funcDeclEquatable))
					return true;
			return false;
		}

		public FuncDeclNode Get(FuncDeclEquatable funcDeclEquatable)
		{
			foreach (FuncDeclNode decl in declarations_)
				if (decl.Equatable.Equals(funcDeclEquatable))
					return decl;
			return null;
		}

		public void Add(FuncDeclNode funcDecl)
		{
			Debug.Assert(funcDecl != null);
			FuncDeclNode previousDecl = Get(funcDecl.Equatable);
			if (previousDecl != null)
				declarations_.Remove(previousDecl);
			declarations_.Add(funcDecl);
		}

		public void Clear()
		{
			declarations_.Clear();
		}

		protected List<FuncDeclNode> declarations_ = new List<FuncDeclNode>();
	}
}
