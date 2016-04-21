/**
 * @interface strange.framework.api.ISemiBinding
 * 
 * A managed list of values.
 * 
 * A SemiBinding is the smallest atomic part of the strange framework. It represents
 * either the Key or the Value or the Name arm of the binding.
 * <br />
 * The SemiBinding stores some value...a system Type, a list, a concrete value.
 * <br />
 * It also has a constraint defined by the constant ONE or MANY.
 * A constraint of ONE makes the SemiBinding maintain a singular value, rather than a list.
 * <br />
 * The default constraints are:
 * <ul>
 *  <li>Key - ONE</li>
 *  <li>Value - MANY</li>
 *  <li>Name - ONE</li>
 * </ul>
 * 
 * @see strange.framework.api.BindingConstraintType
 */

namespace strange.framework.api
{
	public interface ISemiBinding : IManagedList
	{
		/// Set or get the constraint. 
		BindingConstraintType constraint{ get; set;}

		/// A secondary constraint that ensures that this SemiBinding will never contain multiple values equivalent to each other. 
		bool uniqueValues{get;set;}
	}
}
