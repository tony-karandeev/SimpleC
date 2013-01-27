using System.Collections.Generic;

using Antlr.Runtime;
using Antlr.Runtime.Tree;


namespace SimpleC
{
  public class AstNode: CommonTree
  {
    public AstNode()
      : base() {
    }

    public AstNode(IToken t)
      : base(t) {
    }

    public AstNode(CommonTree node)
      : base(node) {
    }
  }
}
