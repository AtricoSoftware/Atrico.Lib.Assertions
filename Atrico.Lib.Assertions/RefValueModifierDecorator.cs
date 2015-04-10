namespace Atrico.Lib.Assertions
{
    public abstract class RefValueModifierDecorator<T> : Decorator where T : class
    {
        public override bool Test(object actual)
        {
            return base.Test(ModifyValue(actual));
        }

        public override string CreateErrorMessage(object actual)
        {
            return base.CreateErrorMessage(ModifyValue(actual));
        }

        protected abstract T ModifyValue(object actual);
    }
}