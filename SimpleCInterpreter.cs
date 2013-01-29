using System;
using System.Globalization;

using Antlr.Runtime.Tree;

using AstNodeType = SimpleC.Grammar.SimpleCParser;


namespace SimpleC
{
    public class SimpleCIntepreter
    {
        // "культуронезависимый" формат для чисел (с разделителем точкой)
        public static readonly NumberFormatInfo NFI = new NumberFormatInfo();

        private ITree programNode = null;


        public SimpleCIntepreter(ITree programNode)
        {
			if (programNode.Type != AstNodeType.PROGRAM)
			{
				Console.Error.WriteLine(String.Format("Node: {0}", Grammar.SimpleCParser.tokenNames[programNode.Type]));
				throw new Interpreter.InterpreterException("AST-дерево не является программой");
			}

            this.programNode = programNode;
        }


        private double ExecuteNode(ITree node)
        {
#if false
            switch (node.Type)
            {
                case AstNodeType.INTEGER:
                    return ((NumAstNode)node).Value;

#if (false)
                case AstNodeType.VAR:
                    VarDescr varDescr = ((VarDefAstNode)node).VarDescr;
                    if (varDescr.Initialized)
                        return varDescr.Value;
                    else
                        throw new ParserBaseException(string.Format("Значение {0} не определено", varDescr.Name));
#endif

                case AstNodeType.ADD:
                    return ExecuteNode(node.GetChild(0)) + ExecuteNode(node.GetChild(1));

                case AstNodeType.SUB:
                    return ExecuteNode(node.GetChild(0)) - ExecuteNode(node.GetChild(1));

                case AstNodeType.MUL:
                    return ExecuteNode(node.GetChild(0)) * ExecuteNode(node.GetChild(1));

                case AstNodeType.DIV:
                    return ExecuteNode(node.GetChild(0)) * ExecuteNode(node.GetChild(1));

                case AstNodeType.ASSIGN:
                    break;
                
                case AstNodeType.FUNC_CALL:
					Console.WriteLine(ExecuteNode(node.GetChild(0)));
                    break;

                case AstNodeType.PROGRAM:
                    for (int i = 0; i < node.ChildCount; i++)
                        ExecuteNode(node.GetChild(i));
                    break;

                default:
                    throw new IntepreterException("Неизвестный тип узла AST-дерева");
            }
#endif
            return 0;
        }


        public void Execute()
        {
            ExecuteNode(programNode);
        }


        public static void Execute(ITree programNode)
        {
            SimpleCIntepreter mei = new SimpleCIntepreter(programNode);
            mei.Execute();
        }
    }
}
