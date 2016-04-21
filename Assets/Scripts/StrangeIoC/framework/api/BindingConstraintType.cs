namespace strange.framework.api
{
	public enum BindingConstraintType
	{
		/// Constrains a SemiBinding to carry no more than one item in its Value
		ONE,
		/// Constrains a SemiBinding to carry a list of items in its Value
		MANY,
		/// Instructs the Binding to apply a Pool instead of a SemiBinding
		POOL,
	}
}
