namespace Atrico.Lib.Assertions
{
	public abstract class ConstraintProviderBase : HasAdaptersBase
	{
		/// <summary>
		///     Constructor
		/// </summary>
		protected ConstraintProviderBase(params IAdapter[] adapters)
			: this(null, adapters)
		{
		}

		/// <summary>
		///     Constructor
		/// </summary>
		protected ConstraintProviderBase(string name, params IAdapter[] adapters)
		{
			var name2 = name ?? new EverythingBefore(GetType().Name, "ConstraintProvider");
			AddAdapters(adapters);
			if (name2 != "") AddNameAdapter(new NameAdapter(name2));
		}
	}
}