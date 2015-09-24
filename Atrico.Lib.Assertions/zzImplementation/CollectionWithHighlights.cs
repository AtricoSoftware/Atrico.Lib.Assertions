using System.Collections;
using System.Collections.Generic;

namespace Atrico.Lib.Assertions.zzImplementation
{
    internal sealed class CollectionWithHighlights
    {
        public IEnumerable Collection { get; private set; }
        public ISet<object> Highlights { get; private set; }

        public CollectionWithHighlights(IEnumerable collection, IEnumerable<object> highlights)
        {
            Collection = collection;
            Highlights = new HashSet<object>(highlights);
        }
    }
}