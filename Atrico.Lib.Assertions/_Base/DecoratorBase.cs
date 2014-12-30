// ReSharper disable once CheckNamespace

namespace Atrico.Lib.Assertions
{
	public abstract class DecoratorBase : IAssertConstraint
	{
		private readonly IAssertConstraint _child;

		protected DecoratorBase(IAssertConstraint child)
		{
			_child = child;
		}

		public virtual string Name
		{
			get { return _child.Name; }
		}

		public virtual bool Test(object actual)
		{
			return _child.Test(actual);
		}

		public virtual object CreateConstraintOperand(object actual)
		{
			return _child.CreateConstraintOperand(actual);
		}

		public virtual string CreateErrorMessage(object actual)
		{
			return _child.CreateErrorMessage(actual);
		}
	}
}
