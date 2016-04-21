/**
 * @class strange.extensions.context.impl.ContextView
 * 
 * The Root View of a Context hierarchy.
 * 
 * Extend this class to create your AppRoot, then attach
 * that MonoBehaviour to the GameObject at the very top of
 * your display hierarchy.
 * 
 * The startup sequence looks like this:

		void Awake()
		{
			context = new MyContext(this, true);
			context.Start ();
		}

 */

using UnityEngine;
using strange.extensions.context.api;

namespace strange.extensions.context.impl
{
	public class ContextView : MonoBehaviour, IContextView
	{
		public IContext context{get;set;}
		
		public ContextView ()
		{
		}

		/// <summary>
		/// When a ContextView is Destroyed, automatically removes the associated Context.
		/// </summary>
		protected virtual void OnDestroy()
		{
			if (context != null && Context.firstContext != null)
				Context.firstContext.RemoveContext(context);
		}

		#region IView implementation

		public bool requiresContext {get;set;}

		public bool registeredWithContext {get;set;}

		public bool autoRegisterWithContext{ get; set; }

		#endregion
	}
}
