// ReSharper disable once CheckNamespace
namespace Atrico.Lib.Assertions
{
	public class NameDecorater : IAssertConstraint
	{
		private readonly string _prependName;
		protected IAssertConstraint Constraint { get; private set; }

		public NameDecorater(string prependName, IAssertConstraint constraint)
		{
			_prependName = prependName;
			Constraint = constraint;
		}

		public string Name
		{
			get { return string.Format("{0}.{1}", _prependName, Constraint.Name); }
		}

		public virtual string CreateErrorMessage(object actual)
		{
			return Constraint.CreateErrorMessage(actual);
		}

		public virtual bool Test(object actual)
		{
			return Constraint.Test(actual);
		}

		public override string ToString()
		{
			return string.Format("{0}: {1}", GetType().Name, _prependName);
		}
	}
}