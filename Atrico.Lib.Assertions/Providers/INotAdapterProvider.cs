// ReSharper disable once CheckNamespace
namespace Atrico.Lib.Assertions
{
	public interface INotAdapterProvider<out TProvider>
	{
		TProvider Not { get; }
	}
}