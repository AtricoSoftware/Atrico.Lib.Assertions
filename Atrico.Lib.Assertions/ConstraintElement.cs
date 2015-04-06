namespace Atrico.Lib.Assertions
{
    public abstract class ConstraintElement<T> : IConstraintElement<T>
    {
        public Decorator Decorator { get; private set; }

        protected ConstraintElement(Decorator decorator)
        {
            Decorator = decorator;
        }
    }
}