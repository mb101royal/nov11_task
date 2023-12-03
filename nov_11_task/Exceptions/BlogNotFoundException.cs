using System.Runtime.Serialization;

namespace nov_11_task.Exceptions
{
	internal class BlogNotFoundException : Exception
	{
		public BlogNotFoundException()
		{
		}

		public BlogNotFoundException(string? message) : base(message)
		{
		}

		public BlogNotFoundException(string? message, Exception? innerException) : base(message, innerException)
		{
		}

		protected BlogNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}
	}
}
