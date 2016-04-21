/**
 * @interface strange.extensions.injector.api.IInjector
 * 
 * Interface for the Injector, which dependencies into provided instances.
 * 
 * The Injector requests a ReflectedClass from the ReflectionBinder
 * and uses that information to inject an instance. Note that the Injector
 * itself does not instantiate the class. That is the job of the
 * InjectorFactory. That said, Factory and Reflector are 'hidden'
 * from the average user, since their jobs are pretty deep in the structure.
 * If you wish, you can override either or both.
 * 
 * Classes utilizing the injector must be marked with the following metatags:
 * <ul>
 *  <li>[Inject] - Use this metatag on any setter you wish to have supplied by injection.</li>
 *  <li>[Construct] - Use this metatag on the specific Constructor you wish to inject into when using Constructor injection. If you omit this tag, the Constructor with the shortest list of dependencies will be selected automatically.</li>
 *  <li>[PostConstruct] - Use this metatag on any method(s) you wish to fire directly after dependencies are supplied</li>
 * </ul>
 * 
 * @see strange.extensions.reflector.api.IReflectionBinder
 * @see strange.extensions.injector.api.IInjectionBinder
 * @see strange.extensions.injector.api.IInjectorFactory
 */

using strange.extensions.reflector.api;

namespace strange.extensions.injector.api
{
	public interface IInjector
	{
		/// Request an instantiation based on the given binding.
		/// This request is made to the Injector, but it's really the InjectorFactory that does the instantiation.
		object Instantiate (IInjectionBinding binding, bool tryInjectHere);

		//Attempt to inject based on binding setting
		object TryInject(IInjectionBinding binding, object target);

		/// Request that the provided target be injected.
		object Inject(object target);

		/// Request that the provided target be injected.
		object Inject(object target, bool attemptConstructorInjection);

		/// Clear the injections from the provided instance.
		/// Note that Uninject can only clean public properties...therefore only
		/// setters will be uninjected...not injections provided via constructor injection
		void Uninject(object target);

		/// Get/set an InjectorFactory.
		IInjectorFactory factory{ get; set;}

		/// Get/set an InjectionBinder.
		IInjectionBinder binder{ get; set;}

		/// Get/set a ReflectionBinder.
		IReflectionBinder reflector{ get; set;}
	}
}
