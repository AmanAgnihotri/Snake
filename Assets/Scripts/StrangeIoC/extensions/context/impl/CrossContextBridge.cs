/**
 * @class strange.extensions.context.impl.CrossContextBridge
 * 
 * A relay for events mapped across multiple Contexts.
 * 
 * This simple class gates events fired by the local Context-wide EventDispatcher.
 * Any event trigger mapped to this Binder will be relayed to the CrossContextDispatcher
 * for consumption by others. This removes the necessity to ever inject the CrossContextDispatcher
 * at an endpoint (e.g., a Command or Mediator).
 * 
 * Because the Bridge itself is mapped cross-context (and
 * therefore shared), it is up to the developer to decide where to make cross-Context the mappings.
 * 
 * This "freedom" is also a potential pitfall; we recommend that you map all Cross-Context
 * events in firstContext to avoid confusion.
 * 
 * Example:

	crossContextBridge.Bind(GameEvent.MISSILE_HIT);

 * By doing this from any Context in your app, any Context Dispatcher that fires `GameEvent.MISSILE_HIT` will
 * relay that Event to other Contexts.
 */

using strange.extensions.dispatcher.api;
using strange.extensions.dispatcher.eventdispatcher.api;
using strange.extensions.context.api;
using strange.framework.api;
using strange.framework.impl;
using System.Collections.Generic;

namespace strange.extensions.context.impl
{
	public class CrossContextBridge : Binder, ITriggerable
	{
		[Inject(ContextKeys.CROSS_CONTEXT_DISPATCHER)]
		public IEventDispatcher crossContextDispatcher{ get; set;}

		/// Prevents the currently dispatching Event from cycling back on itself
		protected HashSet<object> eventsInProgress = new HashSet<object>();

		public CrossContextBridge ()
		{
		}

		override public IBinding Bind(object key)
		{
			IBinding binding;
			binding = GetRawBinding ();
			binding.Bind(key);
			resolver (binding);
			return binding;
		}

		#region ITriggerable implementation

		public bool Trigger<T> (object data)
		{
			return Trigger (typeof(T), data);
		}

		public bool Trigger (object key, object data)
		{
			IBinding binding = GetBinding (key, null);
			if (binding != null && !eventsInProgress.Contains(key))
			{
				eventsInProgress.Add (key);
				crossContextDispatcher.Dispatch (key, data);
				eventsInProgress.Remove (key);
			}
			return true;
		}

		#endregion
	}
}
