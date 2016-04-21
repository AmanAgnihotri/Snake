/**
 *	@interface strange.extensions.command.api.IPooledCommandBinder
 *
 *	Interface for a CommandBinder that allows pooling. Pooling allows Commands to
 *	be recycled, which can be more efficient.
 */

using strange.extensions.pool.impl;

namespace strange.extensions.command.api
{
	public interface IPooledCommandBinder
	{
		/// Retrieve the Pool of the specified type
		Pool<T> GetPool<T>();

		/// Switch to disable pooling for those that don't want to use it.
		bool usePooling{ get; set; }
	}
}
