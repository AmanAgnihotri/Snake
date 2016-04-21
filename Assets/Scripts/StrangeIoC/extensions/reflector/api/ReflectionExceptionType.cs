namespace strange.extensions.reflector.api
{
	public enum ReflectionExceptionType
	{
		/// The reflector requires a constructor, which Interfaces don't provide.
		CANNOT_REFLECT_INTERFACE,

		/// The reflector is not allowed to inject into private/protected setters.
		CANNOT_INJECT_INTO_NONPUBLIC_SETTER,

		/// ListensTo attribute must have a matching Inject tag for the Signal in question
		LISTENS_TO_MUST_HAVE_INJECTION,
	}
}
