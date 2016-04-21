/**
 * @enum strange.extensions.command.api.CommandExceptionType
 * 
 * Errors relating to the CommandBinder
 */

namespace strange.extensions.command.api
{
	public enum CommandExceptionType
	{
		/// Commands must always override the Execute() method.
		EXECUTE_OVERRIDE,
		/// Binding wasn't found
		NULL_BINDING,
		/// Something went wrong during construction, so the Command resolved to null
		BAD_CONSTRUCTOR
	}
}
