namespace Atrico.Lib.Assertions.zzImplementation.Decorators
{
    internal sealed class NotDecorator : Decorator
    {
        public override bool Test(object actual)
        {
            return !base.Test(actual);
        }
    }
}