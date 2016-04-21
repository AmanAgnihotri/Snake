/**
 * @class strange.extensions.command.impl.CommandBinding
 * 
 * The Binding for CommandBinder.
 * 
 * The only real distinction between CommandBinding and Binding
 * is the addition of `Once()`, which signals that the Binding
 * should be destroyed immediately after a single use.
 */

using strange.extensions.command.api;
using strange.framework.impl;

namespace strange.extensions.command.impl
{
	public class CommandBinding : Binding, ICommandBinding
	{
		public bool isOneOff{ get; set; }

		public bool isSequence{ get; set; }

		public bool isPooled{ get; set; }

		public CommandBinding() : base()
		{
			_value.uniqueValues = false;
		}

		public CommandBinding (Binder.BindingResolver resolver) : base(resolver)
		{
			_value.uniqueValues = false;
		}

		public ICommandBinding Once()
		{
			isOneOff = true;
			return this;
		}

		public ICommandBinding InParallel()
		{
			isSequence = false;
			return this;
		}

		public ICommandBinding InSequence()
		{
			isSequence = true;
			return this;
		}

		public ICommandBinding Pooled()
		{
			isPooled = true;
			resolver (this);
			return this;
		}

		//Everything below this point is simply facade on Binding to ensure fluent interface

		new public ICommandBinding Bind<T>()
		{
			return base.Bind<T> () as ICommandBinding;
		}

		new public ICommandBinding Bind(object key)
		{
			return base.Bind (key) as ICommandBinding;
		}

		new public ICommandBinding To<T>()
		{
			return base.To<T> () as ICommandBinding;
		}

		new public ICommandBinding To(object o)
		{
			return base.To (o) as ICommandBinding;
		}

		new public ICommandBinding ToName<T>()
		{
			return base.ToName<T> () as ICommandBinding;
		}

		new public ICommandBinding ToName(object o)
		{
			return base.ToName (o) as ICommandBinding;
		}

		new public ICommandBinding Named<T>()
		{
			return base.Named<T> () as ICommandBinding;
		}

		new public ICommandBinding Named(object o)
		{
			return base.Named (o) as ICommandBinding;
		}
	}
}
