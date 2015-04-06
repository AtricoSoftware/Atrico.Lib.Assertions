namespace Atrico.Lib.Assertions.Implementation.Constraints
{
    internal sealed class TrueConstraint : Constraint<bool>
    {
        public TrueConstraint(Decorator decorator)
            : base(decorator)
        {
        }

        protected override bool TestImpl(bool actual)
        {
            return actual;
        }
    }
}