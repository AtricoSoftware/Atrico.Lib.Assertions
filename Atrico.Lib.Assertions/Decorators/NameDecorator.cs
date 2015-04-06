using System;

namespace Atrico.Lib.Assertions.Decorators
{
    /// <summary>
    ///     Decorator that changes nothing but the name
    /// </summary>
    public sealed class NameDecorator : Decorator
    {
        private readonly Func<string> _nameFunc;

        public static Decorator Create(Func<string> nameFunc)
        {
            return new NameDecorator(nameFunc);
        }

        public static Decorator Create(string format, params object[] args)
        {
            return Create(() => string.Format(format, args));
        }

        private NameDecorator(Func<string> nameFunc)
        {
            _nameFunc = nameFunc;
        }

        protected override string CreateElementName()
        {
            return _nameFunc();
        }
    }
}