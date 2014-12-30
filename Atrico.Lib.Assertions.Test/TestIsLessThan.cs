using System.Diagnostics;
using Atrico.Lib.Testing;
using Atrico.Lib.Testing.NUnitAttributes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Atrico.Lib.Assertions.Test
{
	[TestFixture]
	public class TestIsLessThan
	{
		[Test]
		public void TestIsLessThanPassLess()
		{
			// Arrange
			const int actual = 1;
			const int expected = 2;

			// Act
			var ex = Catch.Exception(() => Assert.That(actual, Is.LessThan(expected)));

			// Assert
			Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsNull(ex);
		}

		[Test]
		public void TestIsLessThanFailEqual()
		{
			// Arrange
			const int actual = 2;
			const int expected = 2;

			// Act
			var ex = Catch.Exception(() => Assert.That(actual, Is.LessThan(expected)));

			// Assert
			Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsInstanceOfType(ex, typeof (AssertFailedException));
		}

		[Test]
		public void TestIsLessThanFailMore()
		{
			// Arrange
			const int actual = 2;
			const int expected = 1;

			// Act
			var ex = Catch.Exception(() => Assert.That(actual, Is.LessThan(expected)));

			// Assert
			Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsInstanceOfType(ex, typeof (AssertFailedException));
		}

		[Test]
		public void TestIsLessThanMessage()
		{
			// Arrange
			const int actual = 2;
			const int expected = 2;

			// Act
			var ex = Catch.Exception(() => Assert.That(actual, Is.LessThan(expected)));

			// Assert
			var expectedMsg = string.Format("Is.LessThan({0}) failed. Actual:<{1}>", expected, actual);
			Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(expectedMsg, ex.Message);
			Debug.WriteLine(ex.Message);
		}

		[Test]
		public void TestIsNotLessThanFailLess()
		{
			// Arrange
			const int actual = 1;
			const int expected = 2;

			// Act
			var ex = Catch.Exception(() => Assert.That(actual, Is.Not.LessThan(expected)));

			// Assert
			Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsInstanceOfType(ex, typeof (AssertFailedException));
		}

		[Test]
		public void TestIsNotLessThanPassEqual()
		{
			// Arrange
			const int actual = 2;
			const int expected = 2;

			// Act
			var ex = Catch.Exception(() => Assert.That(actual, Is.Not.LessThan(expected)));

			// Assert
			Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsNull(ex);
		}

		[Test]
		public void TestIsNotLessThanPassMore()
		{
			// Arrange
			const int actual = 2;
			const int expected = 1;

			// Act
			var ex = Catch.Exception(() => Assert.That(actual, Is.Not.LessThan(expected)));

			// Assert
			Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsNull(ex);
		}

		[Test]
		public void TestIsNotLessThanMessage()
		{
			// Arrange
			const int actual = 1;
			const int expected = 2;

			// Act
			var ex = Catch.Exception(() => Assert.That(actual, Is.Not.LessThan(expected)));

			// Assert
			var expectedMsg = string.Format("Is.Not.LessThan({0}) failed. Actual:<{1}>", expected, actual);
			Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(expectedMsg, ex.Message);
			Debug.WriteLine(ex.Message);
		}
	}
}
