namespace strange.extensions.mediation.api
{
	public enum MediationExceptionType
	{
		/// Exception raised when a View can't locate a Context.
		/// Views contact the Context by "bubbling" their existence up 
		/// the display chain (recursively using transform.parent).
		/// If a View reaches the top of that chain without locating
		/// a Context, it will raise this Exception to warn you.
		/// 
		/// Note: to avoid infinite looping, there is a bubbling limit of 100
		/// layers. If your View needs to be more than 100 transforms deep, 
		/// that might signal a design problem.
		NO_CONTEXT,

		/// Exception raised when a View is mapped to itself.
		/// If a View is accidentally mapped to itself, the result will be an
		/// infinite loop of Mediation creation.
		MEDIATOR_VIEW_STACK_OVERFLOW,

		/// A Binding resolved to null as it was converted (usually from a Binding)
		/// Honestly, this should never happen.
		BINDING_RESOLVED_TO_NULL,

		/// Exception raised when AddComponent results in a null Mediator.
		/// This probably means that the mapped "mediator" wasn't a MonoBehaviour.
		NULL_MEDIATOR,

		/// The mediator type is null on the attribute tag
		IMPLICIT_BINDING_MEDIATOR_TYPE_IS_NULL,
		/// The view type is null on the attribute tag
		IMPLICIT_BINDING_VIEW_TYPE_IS_NULL,

		/// View bound to abstraction that View doesn't actually extend/implement
		VIEW_NOT_ASSIGNABLE,
	}
}
