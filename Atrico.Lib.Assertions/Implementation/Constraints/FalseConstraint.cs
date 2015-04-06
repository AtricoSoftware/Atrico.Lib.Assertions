namespace Atrico.Lib.Assertions.Implementation.Constraints
{
    internal sealed class FalseConstraint : Constraint<bool>
    {
        public FalseConstraint(Decorator decorator)
            : base(decorator)
        {
        }

        protected override bool TestImpl(bool actual)
        {
            return !actual;
        }
    }
}