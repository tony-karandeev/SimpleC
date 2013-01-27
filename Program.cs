using System;
using System.Globalization;

using Antlr.Runtime;
using Antlr.Runtime.Tree;


namespace SimpleC
{
	public class Program
	{
		// "�������������������" ������ ��� ����� (� ������������ ������)
		public static readonly NumberFormatInfo NFI = new NumberFormatInfo();


		public static void Main(string[] args)
		{
			try
			{
				// � ����������� �� ������� ���������� ��������� ������ ���������
				// ���� ���� � ������, ���������� ������ ����������, ���� ����������� ����
				ICharStream input = args.Length == 1 ? (ICharStream)new ANTLRFileStream(args[0])
													 : (ICharStream)new ANTLRReaderStream(Console.In);
				SimpleCLexer lexer = new SimpleCLexer(input);
				CommonTokenStream tokens = new CommonTokenStream(lexer);
				SimpleCParser parser = new SimpleCParser(tokens);
				ITree program = (ITree)parser.program().Tree;
				AstNodePrinter.Print(program);
				Console.WriteLine();
//				SimpleCIntepreter.Execute(program);
				Console.ReadLine();
			}
			catch (Exception e)
			{
				Console.WriteLine("Error: {0}", e);
			}
		}
	}
}
