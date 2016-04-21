/**
 * @class strange.extensions.command.impl.EventCommandBinder
 * 
 * A subclass of CommandBinder which relies on an IEventDispatcher as the common system bus.
 */

using System;
using strange.extensions.command.api;
using strange.extensions.dispatcher.eventdispatcher.api;
using strange.extensions.pool.api;

namespace strange.extensions.command.impl
{
	public class EventCommandBinder : CommandBinder
	{
		public EventCommandBinder ()
		{
		}
		/// 
		override protected ICommand createCommand(object cmd, object data)
		{
			injectionBinder.Bind<ICommand> ().To (cmd);
			if (data is IEvent)
			{
				injectionBinder.Bind<IEvent>().ToValue(data).ToInject(false);
			}

			ICommand command = injectionBinder.GetInstance<ICommand>() as ICommand;
			try
			{
				if (command == null)
				{
					string msg = "A Command ";
					if (data is IEvent)
					{
						IEvent evt = (IEvent) data;
						msg += "tied to event " + evt.type;
					}
					msg += " could not be instantiated.\nThis might be caused by a null pointer" +
            " during instantiation or failing to override Execute (generally you" +
            " shouldn't have constructor code in Commands).";
					throw new CommandException(msg, CommandExceptionType.BAD_CONSTRUCTOR);
				}

				command.data = data;
			}
			catch (Exception)
			{
				throw;
			}
			finally
			{
				if (data is IEvent)
				{
					injectionBinder.Unbind<IEvent>();
				}
				injectionBinder.Unbind<ICommand>();
			}
			
			return command;
		}

		override protected void disposeOfSequencedData(object data)
		{
			if (data is IPoolable)
			{
				(data as IPoolable).Release();
			}
		}
	}
}
