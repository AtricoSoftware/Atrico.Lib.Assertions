// ReSharper disable once CheckNamespace
namespace Atrico.Lib.Assertions
{
	internal static class DecoratorHelper
	{
		public static DecoratorFunction Append(this DecoratorFunction root, DecoratorFunction child)
		{
			if (ReferenceEquals(root, null))
			{
				return child;
			}
			return n => root(child(n));
		}
	}
}
