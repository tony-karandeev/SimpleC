using Antlr.Runtime;

using AstNodeType = MathExpr.MathExprParser;


namespace MathExpr
{
  public class VarAstNode: AstNode
  {
    private VarDescr varDescr = null;


    public VarAstNode(IToken t)
      : base(t) {
    }


    public VarAstNode(int ttype, VarDescr varDescr)
      : base(new CommonToken(AstNodeType.VAR)) {
      VarDescr = varDescr;
    }


    public virtual VarDescr VarDescr {
      get {
        return varDescr;
      }
      set {
        varDescr = value;
      }
    }


    public override string ToString() {
      return VarDescr !=null ? VarDescr.ToString()
                             : base.ToString();
    }
  }
}
