using System.Diagnostics;
using Atrico.Lib.Testing;
using Atrico.Lib.Testing.NUnitAttributes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Atrico.Lib.Assertions.Test
{
	[TestFixture]
	public class TestIsBetween
	{
		[Test]
		public void TestIsBetweenPassMin()
		{
			// Arrange
			const int lowerLimit = 2;
			const int upperLimit = 4;
			const int actual = 2;

			// Act
			var ex = Catch.Exception(() => Assert.That(actual, Is.Between(lowerLimit, upperLimit)));

			// Assert
			Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsNull(ex);
		}

		[Test]
		public void TestIsBetweenPassMax()
		{
			// Arrange
			const int actual = 4;
			const int lowerLimit = 2;
			const int upperLimit = 4;

			// Act
			var ex = Catch.Exception(() => Assert.That(actual, Is.Between(lowerLimit, upperLimit)));

			// Assert
			Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsNull(ex);
		}

		[Test]
		public void TestIsBetweenPassMid()
		{
			// Arrange
			const int actual = 3;
			const int lowerLimit = 2;
			const int upperLimit = 4;

			// Act
			var ex = Catch.Exception(() => Assert.That(actual, Is.Between(lowerLimit, upperLimit)));

			// Assert
			Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsNull(ex);
		}

		[Test]
		public void TestIsBetweenFailBelow()
		{
			// Arrange
			const int actual = 1;
			const int lowerLimit = 2;
			const int upperLimit = 4;

			// Act
			var ex = Catch.Exception(() => Assert.That(actual, Is.Between(lowerLimit, upperLimit)));

			// Assert
			Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsInstanceOfType(ex, typeof (AssertFailedException));
		}

		[Test]
		public void TestIsBetweenFailAbove()
		{
			// Arrange
			const int actual = 54;
			const int lowerLimit = 2;
			const int upperLimit = 4;

			// Act
			var ex = Catch.Exception(() => Assert.That(actual, Is.Between(lowerLimit, upperLimit)));

			// Assert
			Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsInstanceOfType(ex, typeof (AssertFailedException));
		}

		[Test]
		public void TestIsBetweenMessage()
		{
			// Arrange
			const int actual = 1;
			const int lowerLimit = 2;
			const int upperLimit = 4;

			// Act
			var ex = Catch.Exception(() => Assert.That(actual, Is.Between(lowerLimit, upperLimit)));

			// Assert
			var expectedMsg = string.Format("Is.Between({0} -> {1}) failed. Actual:<{2}>", lowerLimit, upperLimit,
			                                actual);
			Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(expectedMsg, ex.Message);
			Debug.WriteLine(ex.Message);
		}

		[Test]
		public void TestIsNotBetweenFailMin()
		{
			// Arrange
			const int actual = 2;
			const int lowerLimit = 2;
			const int upperLimit = 4;

			// Act
			var ex = Catch.Exception(() => Assert.That(actual, Is.Not.Between(lowerLimit, upperLimit)));

			// Assert
			Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsInstanceOfType(ex, typeof (AssertFailedException));
		}

		[Test]
		public void TestIsNotBetweenFailMax()
		{
			// Arrange
			const int actual = 4;
			const int lowerLimit = 2;
			const int upperLimit = 4;

			// Act
			var ex = Catch.Exception(() => Assert.That(actual, Is.Not.Between(lowerLimit, upperLimit)));

			// Assert
			Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsInstanceOfType(ex, typeof (AssertFailedException));
		}

		[Test]
		public void TestIsNotBetweenFailMid()
		{
			// Arrange
			const int actual = 3;
			const int lowerLimit = 2;
			const int upperLimit = 4;

			// Act
			var ex = Catch.Exception(() => Assert.That(actual, Is.Not.Between(lowerLimit, upperLimit)));

			// Assert
			Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsInstanceOfType(ex, typeof (AssertFailedException));
		}

		[Test]
		public void TestIsNotBetweenPassBelow()
		{
			// Arrange
			const int actual = 1;
			const int lowerLimit = 2;
			const int upperLimit = 4;

			// Act
			var ex = Catch.Exception(() => Assert.That(actual, Is.Not.Between(lowerLimit, upperLimit)));

			// Assert
			Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsNull(ex);
		}

		[Test]
		public void TestIsNotBetweenPassAbove()
		{
			// Arrange
			const int actual = 5;
			const int lowerLimit = 2;
			const int upperLimit = 4;

			// Act
			var ex = Catch.Exception(() => Assert.That(actual, Is.Not.Between(lowerLimit, upperLimit)));

			// Assert
			Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsNull(ex);
		}

		[Test]
		public void TestIsNotBetweenMessage()
		{
			// Arrange
			const int actual = 3;
			const int lowerLimit = 2;
			const int upperLimit = 4;

			// Act
			var ex = Catch.Exception(() => Assert.That(actual, Is.Not.Between(lowerLimit, upperLimit)));

			// Assert
			var expectedMsg = string.Format("Is.Not.Between({0} -> {1}) failed. Actual:<{2}>", lowerLimit, upperLimit, actual);
			Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(expectedMsg, ex.Message);
			Debug.WriteLine(ex.Message);
		}
	}
}
