namespace Atrico.Lib.Assertions.zzImplementation.Constraints
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