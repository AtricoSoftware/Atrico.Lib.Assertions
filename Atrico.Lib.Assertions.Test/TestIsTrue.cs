using System.Diagnostics;
using Atrico.Lib.Testing;
using Atrico.Lib.Testing.NUnitAttributes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Atrico.Lib.Assertions.Test
{
	[TestFixture]
	public class TestIsTrue
	{
		[Test]
		public void TestIsTruePass()
		{
			// Arrange
			const bool actual = true;

			// Act
			var ex = Catch.Exception(() => Assert.That(actual, Is.True));

			// Assert
			Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsNull(ex);
		}

		[Test]
		public void TestIsTrueFail()
		{
			// Arrange
			const bool actual = false;

			// Act
			var ex = Catch.Exception(() => Assert.That(actual, Is.True));

			// Assert
			Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsInstanceOfType(ex, typeof (AssertFailedException));
		}

		[Test]
		public void TestIsTrueMessage()
		{
			// Arrange
			const bool actual = false;

			// Act
			var ex = Catch.Exception(() => Assert.That(actual, Is.True));

			// Assert
			var expectedMsg = string.Format("Is.True failed.");
			Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(expectedMsg, ex.Message);
			Debug.WriteLine(ex.Message);
		}

		[Test]
		public void TestIsNotTruePass()
		{
			// Arrange
			const bool actual = false;

			// Act
			var ex = Catch.Exception(() => Assert.That(actual, Is.Not.True));

			// Assert
			Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsNull(ex);
		}

		[Test]
		public void TestIsNotTrueFail()
		{
			// Arrange
			const bool actual = true;

			// Act
			var ex = Catch.Exception(() => Assert.That(actual, Is.Not.True));

			// Assert
			Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsInstanceOfType(ex, typeof (AssertFailedException));
		}

		[Test]
		public void TestIsNotTrueMessage()
		{
			// Arrange
			const bool actual = true;

			// Act
			var ex = Catch.Exception(() => Assert.That(actual, Is.Not.True));

			// Assert
			var expectedMsg = string.Format("Is.Not.True failed.");
			Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(expectedMsg, ex.Message);
			Debug.WriteLine(ex.Message);
		}

		[Test]
		public void TestIsTrueWrongType()
		{
			// Arrange
			const string actual = "123";

			// Act
			var ex = Catch.Exception(() => Assert.That(actual, Is.True));

			// Assert
			Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsNotNull(ex);
			Debug.WriteLine(ex.Message);
			Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsTrue(ex.Message.Contains("OPERAND TYPE:"));
		}
	}
}
