using System.Globalization;

using Antlr.Runtime;

using AstNodeType = MathExpr.MathExprParser;


namespace MathExpr
{
  public class NumAstNode: AstNode
  {
    // "культуронезависимый" формат для чисел (с разделителем точкой)
    public static readonly NumberFormatInfo NFI = new NumberFormatInfo();


    private double value = 0;


    public NumAstNode(IToken t)
      : base(t) {
    }


    public NumAstNode(int ttype, double value)
      : base(new CommonToken(ttype)) {
      Value = value;
    }


    public virtual double Value {
      get {
        return value;
      }
      set {
        this.value = value;
      }
    }


    public override string ToString() {
      return value.ToString(NFI);
    }
  }
}
