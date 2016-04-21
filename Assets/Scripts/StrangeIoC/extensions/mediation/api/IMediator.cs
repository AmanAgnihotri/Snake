using UnityEngine;

namespace strange.extensions.mediation.api
{
	public interface IMediator
	{
		/// Get/set the GameObject that represents the top-most item in this Context
		GameObject contextView {get;set;}

		/// This method fires immediately after instantiation, but before injection.
		/// Override to handle anything that needs to happen prior to injection.
		void PreRegister();

		/// This method fires immediately after injection.
		/// Override to perform the actions you might normally perform in a constructor.
		void OnRegister();

		/// This method fires just before a GameObject will be destroyed.
		/// Override to clean up any listeners, or anything else that might keep the View/Mediator pair from being garbage collected.
		void OnRemove();

		/// This method fires when the GameObject is enabled.
		void OnEnabled();

		/// This method fires when the GameObject is disabled.
		void OnDisabled();
	}
}
