namespace Atrico.Lib.Assertions.zzImplementation.Constraints
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