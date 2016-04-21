namespace strange.framework.api
{
	public enum BinderExceptionType
	{
		/// The binder is being used while one or more Bindings are in conflict
		CONFLICT_IN_BINDER,

		/// A runtime class resolved to null. Usually caused when a class can't be resolved.
		RUNTIME_NULL_VALUE,

		/// A runtime binding was attempted with no 'Bind'
		RUNTIME_NO_BIND,

		/// Detected an unrecognized runtime type.
		RUNTIME_TYPE_UNKNOWN,

		/// A runtime binding tried to add multiple Bind keys. The current binder accepts only a single key.
		RUNTIME_TOO_MANY_KEYS,

		/// A runtime binding tried to add multiple Bind keys. The current binder accepts only a single key.
		RUNTIME_TOO_MANY_VALUES,

		/// A runtime binding tried to add something rejected by the whitelist.
		RUNTIME_FAILED_WHITELIST_CHECK
	}
}
