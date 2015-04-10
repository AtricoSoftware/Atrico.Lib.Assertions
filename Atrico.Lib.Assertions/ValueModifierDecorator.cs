namespace Atrico.Lib.Assertions
{
    public abstract class ValueModifierDecorator<T> : Decorator where T : struct
    {
        public override bool Test(object actual)
        {
            return base.Test(ModifyValue(actual));
        }

        public override string CreateErrorMessage(object actual)
        {
            return base.CreateErrorMessage(ModifyValue(actual));
        }

        protected abstract T? ModifyValue(object actual);
    }
}