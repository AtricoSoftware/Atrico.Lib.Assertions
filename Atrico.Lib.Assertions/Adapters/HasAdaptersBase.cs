using System.Collections.Generic;
using System.Linq;

// ReSharper disable once CheckNamespace

namespace Atrico.Lib.Assertions
{
	public interface IHasAdaptersBase
	{
		void AddAdapters(params IAdapter[] adapters);
		IAssertConstraint Adapt(IAssertConstraint constraint);
	}

	public abstract class HasAdaptersBase : IHasAdaptersBase
	{
		private readonly List<IAdapter> _adapters = new List<IAdapter>();

		public void AddAdapters(params IAdapter[] adapters)
		{
			_adapters.AddRange(adapters);
		}

		internal void AddNameAdapter(NameAdapter adapter)
		{
			if (!adapter.Equals(_adapters.LastOrDefault())) _adapters.Add(adapter);
		}

		protected IAdapter[] Adapters
		{
			get { return _adapters.ToArray(); }
		}

		public IAssertConstraint Adapt(IAssertConstraint constraint)
		{
			return Adapters.Reverse()
				.Aggregate(constraint, (current1, adapter) => adapter.Decorate(current1));
		}
	}
}