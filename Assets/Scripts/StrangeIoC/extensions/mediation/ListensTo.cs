/**
 * @class ListensTo
 * 
 * The `[ListensTo]` attribute provides a shortcut for adding
 * Signal-to-Method binding with Mediators.
 * Example:

		[ListensTo(typeof(PlayerUpdateSignal))]
		public void onPlayerUpdate(int hitpoints)
		{
			//do some stuff
		}
 *
 * The above example performs PlayerUpdateSignal.AddListener(onPlayerUpdate)
 * within OnRegister, and PlayerUpdateSignal.RemoveListener(onPlayerUpdate)
 * within OnRemove.
 *
 * NOTE: THE LISTENING METHOD MUST BE MARKED PUBLIC. Private and protected
 * methods are not scanned and the ListensTo attribute will be silently
 * ignored.
 */

using System;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
public class ListensTo : Attribute
{
	public ListensTo(){}

	public ListensTo(Type t)
	{
		type = t;
	}

	public Type type {get; set;}
}
