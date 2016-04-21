using System;
using strange.framework.api;

namespace strange.framework.impl
{
	public class BinderException : Exception
	{
		public BinderExceptionType type{ get; set;}

		public BinderException() : base()
		{
		}

		/// Constructs a BinderException with a message and BinderExceptionType
		public BinderException(string message, BinderExceptionType exceptionType) : base(message)
		{
			type = exceptionType;
		}
	}
}
