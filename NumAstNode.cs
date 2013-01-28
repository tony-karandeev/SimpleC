using System;
using System.Globalization;

using Antlr.Runtime;

using AstNodeType = SimpleC.Grammar.SimpleCParser;


namespace SimpleC
{
    public class NumAstNode : AstNode
    {
        // "культуронезависимый" формат для чисел (с разделителем точкой)
        public static readonly NumberFormatInfo nfi = new NumberFormatInfo();


        private double value = 0;


        public NumAstNode(IToken t)
            : base(t)
        {
        }


		//public NumAstNode(int tokenType, double value)
		//    : base(new CommonToken(tokenType))
		//{
		//    Value = value;
		//}

		public NumAstNode(int tokenType, string valueString)
			: base(new CommonToken(tokenType))
		{
			Value = Double.Parse(valueString, nfi);
		}

        public virtual double Value
        {
            get
            {
                return value;
            }
            set
            {
                this.value = value;
            }
        }


        public override string ToString()
        {
            return value.ToString(nfi);
        }
    }
}
