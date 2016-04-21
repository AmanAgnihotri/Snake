/**
 * @interface strange.extensions.context.api.IContext
 * 
 * A Context is the entry point to the binding framework.
 * 
 * Implement this interface to create the binding context suitable for your application.
 * 
 * In a typical Unity3D setup, an extension of MVCSContext should be instantiated from the ContextView.
 */

using strange.framework.api;
using strange.extensions.dispatcher.api;

namespace strange.extensions.context.api
{
	public interface IContext : IBinder
	{
		/// Kicks off the internal Context binding/instantiation mechanisms 
		IContext Start();

		/// Fires ContextEvent.START (or the equivalent Signal) to launch the application
		void Launch();
		
		/// Register a new context to this one
		IContext AddContext(IContext context);
		
		/// Remove a context from this one
		IContext RemoveContext(IContext context);
		
		/// Register a view with this context
		void AddView(object view);
		
		/// Remove a view from this context
		void RemoveView(object view);

		/// Enables a view in this context
		void EnableView(object view);

		/// Disables a view in this context
		void DisableView(object view);

		/// Get the ContextView
		object GetContextView();

	}
}
