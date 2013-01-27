using System;
using System.Globalization;

using Antlr.Runtime.Tree;

using AstNodeType = MathExpr.MathExprParser;


namespace MathExpr
{
  public class MathExprIntepreter
  {
    // "культуронезависимый" формат для чисел (с разделителем точкой)
    public static readonly NumberFormatInfo NFI = new NumberFormatInfo();

    private ITree programNode = null;


    public MathExprIntepreter(ITree programNode) {
      if (programNode.Type != AstNodeType.PROGRAM)
        throw new IntepreterException("AST-дерево не является программой");

      this.programNode = programNode;
    }


    private double ExecuteNode(ITree node) {
      switch (node.Type) {
        case AstNodeType.UNKNOWN:
          throw new IntepreterException("Неопределенный тип узла AST-дерева");

        case AstNodeType.NUMBER:
          return ((NumAstNode)node).Value;

        case AstNodeType.VAR:
          VarDescr varDescr = ((VarAstNode)node).VarDescr;
          if (varDescr.Initialized)
            return varDescr.Value;
          else
            throw new ParserBaseException(string.Format("Значение {0} не определено", varDescr.Name));

        case AstNodeType.ADD:
          return ExecuteNode(node.GetChild(0)) + ExecuteNode(node.GetChild(1));

        case AstNodeType.SUB:
          return ExecuteNode(node.GetChild(0)) - ExecuteNode(node.GetChild(1));

        case AstNodeType.MUL:
          return ExecuteNode(node.GetChild(0)) * ExecuteNode(node.GetChild(1));

        case AstNodeType.DIV:
          return ExecuteNode(node.GetChild(0)) * ExecuteNode(node.GetChild(1));

        case AstNodeType.ASSIGN:
          varDescr = ((VarAstNode)node.GetChild(0)).VarDescr;
          varDescr.Value = ExecuteNode(node.GetChild(1));
          break;

        case AstNodeType.PRINT:
          Console.WriteLine(ExecuteNode(node.GetChild(0)).ToString(NFI));
          break;

        case AstNodeType.BLOCK:
        case AstNodeType.PROGRAM:
          for (int i = 0; i < node.ChildCount; i++)
            ExecuteNode(node.GetChild(i));
          break;

        default:
          throw new IntepreterException("Неизвестный тип узла AST-дерева");
      }

      return 0;
    }


    public void Execute() {
      ExecuteNode(programNode);
    }


    public static void Execute(ITree programNode) {
      MathExprIntepreter mei=new MathExprIntepreter(programNode);
      mei.Execute();
    }
  }
}
