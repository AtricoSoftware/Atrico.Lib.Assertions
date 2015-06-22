using System.Collections;
using System.Collections.Generic;
using Atrico.Lib.Assertions.Constraints;
using Atrico.Lib.Assertions.Elements;
using Atrico.Lib.Testing;
using Atrico.Lib.Testing.TestAttributes.NUnit;

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
            var actual = new CustomObjectEnumerableT(new[] {1, 2, 3, 4});
            var expected = new[] {1, 2, 3, 4};

            // Act
            var ex = Catch.Exception(() => Assert.That(Value.Of(actual).Is().EqualTo(expected)));

            // Assert
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsNull(ex);
        }
        [Test]
        public void TestNonTypedCollectionObject()
        {
            // Arrange
            var actual = new CustomObjectEnumerable(new[] {1, 2, 3, 4});

            // Act
            var ex = Catch.Exception(() => Assert.That(Value.Of(actual).Count().Is().EqualTo(4)));

            // Assert
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsNull(ex);
        }

        private class CustomObjectEnumerableT : IEnumerable<int>
        {
            private readonly List<int> _list;

            public CustomObjectEnumerableT(IEnumerable<int> ints)
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

        private class CustomObjectEnumerable : IEnumerable
        {
            private readonly ArrayList _list;

            public CustomObjectEnumerable(ICollection values)
            {
                _list = new ArrayList(values);
            }

            public IEnumerator GetEnumerator()
            {
                return _list.GetEnumerator();
            }
        }
    }
}