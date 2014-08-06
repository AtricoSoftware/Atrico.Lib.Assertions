using System.Collections;
using System.Collections.Generic;
using Atrico.Lib.Testing;
using Atrico.Lib.Testing.NUnitAttributes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Atrico.Lib.Assertions.Test
{
	[TestFixture]
	public class TestAsCollectionIsEquivalentToCustomComparer
	{
		private class CustomComparer : IComparer
		{
			public int Compare(object a, object e)
			{
				var iA = (int)a;
				var iE = (int)e;
				return iA.CompareTo(iE/2);
			}
		}

		[Test]
		public void TestAsCollectionIsEquivalentToPassPredicate()
		{
			// Arrange
			var actual = new List<int> {1, 2, 3, 4};
			var expected = new[] {2, 4, 6, 8};

			// Act
			var ex = Catch.Exception(() => Assert.That(actual, AsCollection.Is.EquivalentTo(expected, (a, e) => ((int)a).Equals(((int)e)/2))));

			// Assert
			Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsNull(ex);
		}

		[Test]
		public void TestAsCollectionIsEquivalentToFailPredicate()
		{
			// Arrange
			var actual = new List<int> {1, 2, 3, 4};
			var expected = new[] {1, 2, 3, 4};

			// Act
			var ex = Catch.Exception(() => Assert.That(actual, AsCollection.Is.EquivalentTo(expected, (a, e) => ((int)a).Equals(((int)e)/2))));

			// Assert
			Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsInstanceOfType(ex, typeof(AssertFailedException));
		}

		[Test]
		public void TestAsCollectionIsEquivalentToPassComparer()
		{
			// Arrange
			var actual = new List<int> {1, 2, 3, 4};
			var expected = new[] {2, 4, 6, 8};

			// Act
			var ex = Catch.Exception(() => Assert.That(actual, AsCollection.Is.EquivalentTo(expected, new CustomComparer())));

			// Assert
			Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsNull(ex);
		}

		[Test]
		public void TestAsCollectionIsEquivalentToFailComparer()
		{
			// Arrange
			var actual = new List<int> {1, 2, 3, 4};
			var expected = new[] {1, 2, 3, 4};

			// Act
			var ex = Catch.Exception(() => Assert.That(actual, AsCollection.Is.EquivalentTo(expected, new CustomComparer())));

			// Assert
			Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsInstanceOfType(ex, typeof(AssertFailedException));
		}
	}
}