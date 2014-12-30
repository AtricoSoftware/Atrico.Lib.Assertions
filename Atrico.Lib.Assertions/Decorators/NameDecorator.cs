// ReSharper disable once CheckNamespace

namespace Atrico.Lib.Assertions
{
	/// <summary>
	/// Decorator to prepend to name (with dot separator)
	/// </summary>
	public sealed class NameDecorator : DecoratorBase
	{
		private readonly string _name;

		public static DecoratorFunction Create(string name)
		{
			return n => new NameDecorator(name, n);
		}

		private NameDecorator(string name, IAssertConstraint child)
			: base(child)
		{
			_name = name;
		}

		public override string Name
		{
			get
			{
				var pre = _name;
				var post = base.Name;
				if (string.IsNullOrWhiteSpace(pre))
				{
					return post;
				}
				return pre + (string.IsNullOrWhiteSpace(post) ? "" : "." + post);
			}
		}
	}
}
