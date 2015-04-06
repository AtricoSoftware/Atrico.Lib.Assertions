using System.Collections;
using Atrico.Lib.Assertions.Implementation;
using Atrico.Lib.Common.Collections;

// ReSharper disable once CheckNamespace

namespace Atrico.Lib.Assertions.Decorators
{
    /// <summary>
    ///     Helper to format an error message for unary constraint
    /// </summary>
    public class UnaryErrorMessageDecorator : NameLessDecorator
    {
        private readonly string _actualFormat;

        public UnaryErrorMessageDecorator(string actualFormat = null)
        {
            _actualFormat = actualFormat ?? "Actual:<{0}>";
        }

        /// <summary>
        ///     Throw error with actual, format specified
        /// </summary>
        /// <param name="actual">Actual value</param>
        public override string CreateErrorMessage(object actual)
        {
            return string.Format(_actualFormat, FormatObject(actual));
        }

        internal static string FormatObject(object obj)
        {
            if (ReferenceEquals(obj, null))
            {
                return "null";
            }
            var enumerable = obj as IEnumerable;
            if (enumerable != null && !(obj is string))
            {
                return enumerable.ToCollectionString();
            }
            var collectionWithHighlights = obj as CollectionWithHighlights;
            if (collectionWithHighlights != null)
            {
                return collectionWithHighlights.Collection.ToCollectionString(collectionWithHighlights.Highlights);
            }
            return obj.ToString();
        }
    }
}