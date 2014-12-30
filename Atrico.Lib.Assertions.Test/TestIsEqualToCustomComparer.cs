using System.Collections;
using Atrico.Lib.Testing;
using Atrico.Lib.Testing.NUnitAttributes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Atrico.Lib.Assertions.Test
{
	[TestFixture]
	public class TestIsEqualToCustomComparer
	{
		private class CustomComparer : IComparer
		{
			public int Compare(object a, object e)
			{
				var iA = (int) a;
				var iE = (int) e;
				return iA.CompareTo(iE / 2);
			}
		}

		[Test]
		public void TestEqualToPassPredicate()
		{
			// Arrange
			const int actual = 1;
			const int expected = 2;

			// Act
			var ex = Catch.Exception(() => Assert.That(actual, Is.EqualTo(expected, (a, e) => ((int) a).Equals(((int) e) / 2))));

			// Assert
			Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsNull(ex);
		}

		[Test]
		public void TestEqualToFailPredicate()
		{
			// Arrange
			const int actual = 1;
			const int expected = 1;

			// Act
			var ex = Catch.Exception(() => Assert.That(actual, Is.EqualTo(expected, (a, e) => ((int) a).Equals(((int) e) / 2))));

			// Assert
			Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsInstanceOfType(ex, typeof (AssertFailedException));
		}

		[Test]
		public void TestEqualToPassComparer()
		{
			// Arrange
			const int actual = 1;
			const int expected = 2;

			// Act
			var ex = Catch.Exception(() => Assert.That(actual, Is.EqualTo(expected, new CustomComparer())));

			// Assert
			Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsNull(ex);
		}

		[Test]
		public void TestEqualToFailComparer()
		{
			// Arrange
			const int actual = 1;
			const int expected = 1;

			// Act
			var ex = Catch.Exception(() => Assert.That(actual, Is.EqualTo(expected, new CustomComparer())));

			// Assert
			Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsInstanceOfType(ex, typeof (AssertFailedException));
		}
	}
}
