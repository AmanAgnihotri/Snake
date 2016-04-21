/*
* Flags to interrupt the Context startup process.
*/

using System;

namespace strange.extensions.context.api
{
	[Flags]
	public enum ContextStartupFlags
	{
		/// Context will map bindings and launch automatically (default).
		AUTOMATIC = 0,
		/// Context startup will halt after Core bindings are mapped, but before instantiation or any custom bindings.
		/// If this flag is invoked, the developer must call context.Start()
		MANUAL_MAPPING = 1,
		/// Context startup will halt after all bindings are mapped, but before firing ContextEvent.START (or the analogous Signal).
		/// If this flag is invoked, the developer must call context.Launch()
		MANUAL_LAUNCH = 2,
	}
}
