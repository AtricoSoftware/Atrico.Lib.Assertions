namespace Atrico.Lib.Assertions.zzImplementation.Decorators
{
    internal sealed class NullableValueDecorator<T> : ValueModifierDecorator<T> where T : struct
    {
        protected override T? ModifyValue(object actual)
        {
            return (actual as T?) ?? null;
        }
    }
}