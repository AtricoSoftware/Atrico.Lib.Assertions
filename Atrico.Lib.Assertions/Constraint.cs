using Atrico.Lib.Assertions.Decorators;
using Atrico.Lib.Assertions.zzImplementation.Decorators;
using Atrico.Lib.Common;

namespace Atrico.Lib.Assertions
{
    public abstract class Constraint<T> : ObjectWithElementName, INamedObject
    {
        private readonly Decorator _decorator;

        protected Constraint(Decorator decorator)
        {
            _decorator = decorator
                .Append(NameDecorator.Create(CreateElementName))
                .Append(new PredicateDecorator<T>(TestImpl));
        }

        public bool Check()
        {
            return _decorator.Test(null);
        }

        public string ErrorMessage
        {
            get { return _decorator.CreateErrorMessage(null); }
        }

        public string Name
        {
            get { return _decorator.Name; }
        }

        protected override string ElementNameBase
        {
            get { return "Constraint"; }
        }

        protected abstract bool TestImpl(T actual);
    }
}