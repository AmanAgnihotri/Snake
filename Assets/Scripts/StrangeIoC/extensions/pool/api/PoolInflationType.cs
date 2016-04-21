namespace strange.extensions.pool.api
{
	public enum PoolInflationType
	{
		/// When a dynamic pool inflates, add one to the pool.
		INCREMENT,

		/// When a dynamic pool inflates, double the size of the pool
		DOUBLE
	}
}
