using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bytebank_ATENDIMENTO
{

	[Serializable]
	public class ByteMyException : Exception
	{
		public ByteMyException() { }
		public ByteMyException(string message) : base("Houve uma exceção -> " + message) { }
		public ByteMyException(string message, Exception inner) : base(message, inner) { }
		protected ByteMyException(
		  System.Runtime.Serialization.SerializationInfo info,
		  System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
	}
}
