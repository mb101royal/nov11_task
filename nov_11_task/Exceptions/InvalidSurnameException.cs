using System.Runtime.Serialization;

namespace nov_11_task.Exceptions
{
	internal class InvalidSurnameException : Exception
	{
		public InvalidSurnameException()
		{
		}

		public InvalidSurnameException(string? message) : base(message)
		{
		}

		public InvalidSurnameException(string? message, Exception? innerException) : base(message, innerException)
		{
		}

		protected InvalidSurnameException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}
	}
}
