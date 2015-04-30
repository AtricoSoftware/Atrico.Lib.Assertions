using System.Collections;

namespace Atrico.Lib.Assertions.Decorators
{
    public class BinaryErrorMessageWithTypeDecorator : BinaryErrorMessageDecorator
    {
        public BinaryErrorMessageWithTypeDecorator(object expected, string actualFormat = null, string expectedFormat = null)
            : base(expected, actualFormat, expectedFormat)
        {
        }

        protected override string FormatObject(object obj)
        {
            return base.FormatObject(ObjectWithType.Create(obj));
        }

        private class ObjectWithType
        {
            private readonly object _obj;

            public static object Create(object obj)
            {
                if (ReferenceEquals(obj, null))
                {
                    return null;
                }
                if (obj is IEnumerable && !(obj is string))
                {
                    return obj;
                }
                return new ObjectWithType(obj);
            }

            private ObjectWithType(object obj)
            {
                _obj = obj;
            }

            public override string ToString()
            {
                return string.Format("{0} [{1}]", _obj, _obj.GetType().Name);
            }
        }
    }
}
