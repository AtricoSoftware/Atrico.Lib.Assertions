namespace Atrico.Lib.Assertions
{
	public static class ConstraintProviderHelper
	{
		public static T AddAdapter<T>(this T provider, IAdapter adapter) where T : ConstraintProviderBase
		{
			provider.AddAdapters(adapter);
			return provider;
		}
	}
}