/** 
 * @interface strange.framework.api.IInstanceProvider
 *
 * Provides an instance of the specified Type
 * When all you need is a new instance, use this instead of IInjectionBinder.
 */

using System;

namespace strange.framework.api
{
	public interface IInstanceProvider
	{
		/// Retrieve an Instance based on the key.
		/// ex. `injectionBinder.Get<cISomeInterface>();`
		T GetInstance<T>();

		/// Retrieve an Instance based on the key.
		/// ex. `injectionBinder.Get(typeof(ISomeInterface));`
		object GetInstance(Type key);
	}
}
