using System;
using System.Collections.Generic;
using System.Text;

using Antlr.Runtime;
using AstNodeType = SimpleC.Grammar.SimpleCParser;

namespace SimpleC
{

	public class VarSpec
	{
		public VarSpec(TypeSpec typeSpec, string name)
		{
			Name = name;
			TypeSpec = typeSpec;
		}
		public string Name { get; set; }
		public TypeSpec TypeSpec { get; set; }
	}

    public class VarSpecAstNode : AstNode
    {
        public VarSpecAstNode(IToken t)
            : base(t)
        {
        }

        public VarSpecAstNode(int tokenType, TypeSpec typeSpec, string name)
            : base(new CommonToken(AstNodeType.VAR_SPEC))
        {
			VarSpec = new VarSpec(typeSpec, name);
        }

        public override int Type
        {
            get { return AstNodeType.VAR_SPEC; }
        }

        public override string ToString()
        {
            return String.Format("VarSpecAstNode Name = \"{0}\" Type = \"{1}\""
                , this.Name, this.Type);
        }

		public VarSpec VarSpec { get; set; }
		public string Name { get { return VarSpec.Name; } set { VarSpec.Name = value; } }
		public TypeSpec TypeSpec { get { return VarSpec.TypeSpec; } set { VarSpec.TypeSpec = value; } }
    }
}
