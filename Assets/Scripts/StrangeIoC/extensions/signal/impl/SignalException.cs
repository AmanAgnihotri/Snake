/**
 * @class strange.extensions.signal.impl.SignalException
 * 
 * An exception thrown by the Signal system.
 */

using System;
using strange.extensions.signal.api;

namespace strange.extensions.signal.impl
{
	public class SignalException : Exception
	{

		public SignalExceptionType type { get; set; }
		public SignalException() : base() {}

		/// Constructs a SignalException with a message and SignalExceptionType
		public SignalException(string message, SignalExceptionType exceptionType) : base(message)
		{
			type = exceptionType;
		}
	}
}
