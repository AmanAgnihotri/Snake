using System;
using strange.extensions.pool.api;

namespace strange.extensions.pool.impl
{
	public class PoolException : Exception
	{
		public PoolExceptionType type{ get; set;}

		public PoolException() : base() {}

		/// Constructs a PoolException with a message and PoolExceptionType
		public PoolException(string message, PoolExceptionType exceptionType) : base(message)
		{
			type = exceptionType;
		}
	}
}
