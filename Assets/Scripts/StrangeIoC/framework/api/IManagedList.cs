/**
 * @interface strange.framework.api.IManagedList
 * 
 * A common interface for the constituents parts of a Binding, which at present
 * are either a SemiBinding or a Pool. A ManagedList can have objects added or removed.
 */

namespace strange.framework.api
{
	public interface IManagedList
	{
		/// Add a value to this List. 
		IManagedList Add(object value);

		/// Add a set of values to this List. 
		IManagedList Add(object[] list);

		/// Remove a value from this List. 
		IManagedList Remove(object value);

		/// Remove a set of values from this List. 
		IManagedList Remove(object[] list);

		/// Retrieve the value of this List.
		/// If the constraint is MANY, the value will be an Array.
		/// If the constraint is POOL, this becomes a synonym for GetInstance().
		object value{ get; }
	}
}
