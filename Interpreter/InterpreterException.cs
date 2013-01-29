using System;
using System.Runtime.Serialization;


namespace SimpleC.Interpreter
{
	public class InterpreterException : ApplicationException
	{
		public InterpreterException()
			: base()
		{
		}

		public InterpreterException(string message)
			: base(message)
		{
		}

		public InterpreterException(string message, Exception innerException)
			: base(message, innerException)
		{
		}

		public InterpreterException(SerializationInfo info, StreamingContext context)
			: base(info, context)
		{
		}
	}
}
