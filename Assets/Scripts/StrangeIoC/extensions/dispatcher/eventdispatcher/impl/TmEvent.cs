/**
 * @class strange.extensions.dispatcher.eventdispatcher.impl.TmEvent
 * 
 * The standard Event object for IEventDispatcher.
 * 
 * The TmEvent has three proeprties:
 * <ul>
 *  <li>type - The key for the event trigger</li>
 *  <li>target - The Dispatcher that fired the event</li>
 *  <li>data - An arbitrary payload</li>
 * </ul>
 */

using strange.extensions.dispatcher.eventdispatcher.api;
using strange.extensions.pool.api;

namespace strange.extensions.dispatcher.eventdispatcher.impl
{
	public class TmEvent : IEvent, IPoolable
	{
		public object type{ get; set; }
		public IEventDispatcher target{ get; set; }
		public object data{ get; set; }

		protected int retainCount;

		public TmEvent()
		{
		}

		/// Construct a TmEvent
		public TmEvent(object type, IEventDispatcher target, object data)
		{
			this.type = type;
			this.target = target;
			this.data = data;
		}

		#region IPoolable implementation

		public void Restore ()
		{
			this.type = null;
			this.target = null;
			this.data = null;
		}

		public void Retain()
		{
			retainCount++;
		}

		public void Release()
		{
			retainCount--;
			if (retainCount == 0)
			{
				target.ReleaseEvent (this);
			}
		}

		public bool retain{ 
			get
			{
				return retainCount > 0;
			}
		}

		#endregion
	}
}
