using System.Collections;
using System.Collections.Generic;
using Atrico.Lib.Assertions.Constraints;
using Atrico.Lib.Assertions.Elements;
using Atrico.Lib.Testing;
using Atrico.Lib.Testing.NUnitAttributes;

namespace Atrico.Lib.Assertions.Test
{
    [TestFixture]
    public class TestCollection
    {
        [Test]
        public void TestCollectionArrayEqualToArray()
        {
            // Arrange
            var actual = new[] {1, 2, 3, 4};
            var expected = new[] {1, 2, 3, 4};

            // Act
            var ex = Catch.Exception(() => Assert.That(Value.Of(actual).Is().EqualTo(expected)));

            // Assert
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsNull(ex);
        }

        [Test]
        public void TestCollectionListEqualToArray()
        {
            // Arrange
            var actual = new List<int>(new[] {1, 2, 3, 4});
            var expected = new[] {1, 2, 3, 4};

            // Act
            var ex = Catch.Exception(() => Assert.That(Value.Of(actual).Is().EqualTo(expected)));

            // Assert
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsNull(ex);
        }

        [Test]
        public void TestCollectionArrayEqualToList()
        {
            // Arrange
            var actual = new[] {1, 2, 3, 4};
            var expected = new List<int>(new[] {1, 2, 3, 4});

            // Act
            var ex = Catch.Exception(() => Assert.That(Value.Of(actual).Is().EqualTo(expected)));

            // Assert
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsNull(ex);
        }

        [Test]
        public void TestCollectionObjectEqualToArray()
        {
            // Arrange
            var actual = new CustomObject(new[] {1, 2, 3, 4});
            var expected = new[] {1, 2, 3, 4};

            // Act
            var ex = Catch.Exception(() => Assert.That(Value.Of(actual).Is().EqualTo(expected)));

            // Assert
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsNull(ex);
        }

        private class CustomObject : IEnumerable<int>
        {
            private readonly List<int> _list;

            public CustomObject(IEnumerable<int> ints)
            {
                _list = new List<int>(ints);
            }

            public IEnumerator<int> GetEnumerator()
            {
                return _list.GetEnumerator();
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }
        }
    }
}