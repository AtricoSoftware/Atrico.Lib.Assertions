using System.Collections;
using System.Text;

// ReSharper disable once CheckNamespace
namespace Atrico.Lib.Assertions
{
	/// <summary>
	///     Interface for an assertion constraint with binary test
	/// </summary>
	public abstract class AssertConstraintBase : IAssertConstraint
	{
		private readonly NameByConvention _name;

		public virtual string Name
		{
			get { return _name; }
		}

		public abstract string CreateErrorMessage(object actual);

		public abstract bool Test(object actual);

		/// <summary>
		///     Constructor
		/// </summary>
		protected AssertConstraintBase()
		{
			_name = new EverythingBefore(GetType().Name, "Constraint");
		}

		protected string CreateFormattedActual(object actual)
		{
			return string.Format(ActualFormat, ActualToStringNullProtected(actual));
		}

		protected virtual string ActualFormat
		{
			get { return "Actual:<{0}>"; }
		}

		protected virtual string ActualToString(object actual)
		{
			if (actual is IEnumerable && !(actual is string))
				return FormatCollection(actual as IEnumerable);
			return actual.ToString();
		}

		protected string FormatCollection(IEnumerable enumerable)
		{
			var first = true;
			var text = new StringBuilder("[");
			foreach (var item in enumerable)
			{
				if (!first)
					text.Append(',');
				else
					first = false;
				text.Append(item);
			}
			text.Append(']');
			return text.ToString();
		}

		private string ActualToStringNullProtected(object actual)
		{
			return ReferenceEquals(actual, null) ? "null" : ActualToString(actual);
		}
	}
}