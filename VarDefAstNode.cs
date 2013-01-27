using Antlr.Runtime;

using AstNodeType = SimpleC.SimpleCParser;


namespace SimpleC
{
	public class VarDefAstNode : AstNode
	{
		public VarDefAstNode(IToken t)
			: base(t)
		{
		}

		public VarDefAstNode(int tokenType, VarSpec varSpec)
			: base(new CommonToken(AstNodeType.VAR_DEF))
		{
			VarSpec = varSpec;
		}


		public override int Type
		{
			get { return AstNodeType.VAR_DEF; }
		}

		public override string ToString()
		{
			if (TypeSpec == null || Name == null)
				return base.ToString();
			return TypeSpec.ToString() + " " + Name;
		}

		public VarSpec VarSpec { get; set; }
		public string Name { get { return VarSpec.Name; } set { VarSpec.Name = value; } }
		public TypeSpec TypeSpec { get { return VarSpec.TypeSpec; } set { VarSpec.TypeSpec = value; } }
	}
}
