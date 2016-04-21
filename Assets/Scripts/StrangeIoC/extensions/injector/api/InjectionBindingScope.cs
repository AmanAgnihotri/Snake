namespace strange.extensions.injector.api
{
	public enum InjectionBindingScope
	{
		/// Scope is limited to the current Context
        SINGLE_CONTEXT,
		/// Scope is mapped across all Contexts
        CROSS_CONTEXT,
	}
}
