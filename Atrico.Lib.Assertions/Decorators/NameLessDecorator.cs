namespace Atrico.Lib.Assertions.Decorators
{
    /// <summary>
    ///     Decorator that does not change name
    /// </summary>
    public abstract class NameLessDecorator : Decorator
    {
        protected override string CreateElementName()
        {
            return "";
        }
    }
}
