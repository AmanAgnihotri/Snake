/**
 * @class strange.extensions.injector.api.CrossContextInjectionBinder
 * 
 * A special version of InjectionBinder that allows shared injections across multiple Contexts.
 * 
 * @see strange.extensions.injector.api.IInjectionBinder
 */

namespace strange.extensions.injector.api
{
	public interface ICrossContextInjectionBinder : IInjectionBinder
	{
		//Cross-context Injection Binder is shared across all child contexts
		IInjectionBinder CrossContextBinder { get; set; }
	}
}
