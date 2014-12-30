// ReSharper disable once CheckNamespace
namespace Atrico.Lib.Assertions
{
	public interface INotProvider<out TProvider>
	{
		TProvider Not { get; }
	}
}
