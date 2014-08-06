// ReSharper disable once CheckNamespace
namespace Atrico.Lib.Assertions
{
	public class NameAdapter : IAdapter
	{
		private readonly string _prependName;

		/// <summary>
		///     Constructor
		/// </summary>
		public NameAdapter(string prependName)
		{
			_prependName = prependName;
		}

		public IAssertConstraint Decorate(IAssertConstraint constraint)
		{
			return new NameDecorater(_prependName, constraint);
		}

		public override string ToString()
		{
			return string.Format("NameAdapter: {0}", _prependName);
		}

		public override bool Equals(object obj)
		{
			var adapter = obj as NameAdapter;
			return !ReferenceEquals(adapter, null) && _prependName.Equals(adapter._prependName);
		}

		public override int GetHashCode()
		{
			return _prependName.GetHashCode();
		}
	}
}