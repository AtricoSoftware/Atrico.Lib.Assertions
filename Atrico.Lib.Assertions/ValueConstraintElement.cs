namespace Atrico.Lib.Assertions
{
    public abstract class ValueConstraintElement<T> : ConstraintElement<T>, IValueConstraintElement<T>
    {
        protected ValueConstraintElement(Decorator decorator)
            : base(decorator)
        {
        }
    }
}