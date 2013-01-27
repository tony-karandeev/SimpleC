using System;
using System.Collections.Generic;
using System.Text;

public enum VarType
{
	INT
}

namespace SimpleC
{
    public class TypeSpec
    {
        public TypeSpec(string name)
        {
            Name = name;

			if (name == "int")
				Type = VarType.INT;
        }

        public string Name { get; set; }
		public VarType Type { get; set; }
    }
}
