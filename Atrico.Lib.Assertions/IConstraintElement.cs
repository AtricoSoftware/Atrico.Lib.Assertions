namespace Atrico.Lib.Assertions
{
    public interface IConstraintElement<out T>
    {
        Decorator Decorator { get; }
    }
}