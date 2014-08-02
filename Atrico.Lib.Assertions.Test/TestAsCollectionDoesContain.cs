using System.Diagnostics;
using Atrico.Lib.Testing;
using Atrico.Lib.Testing.NUnitAttributes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Atrico.Lib.Assertions.Test
{
	[TestFixture]
	public class TestAsCollectionDoesContain
	{
		[Test]
		public void TestAsCollectionDoesContainPass()
		{
			// Arrange
			var actual = new[] {1, 2, 3, 4};
			const int expected = 3;

			// Act
			var ex = Catch.Exception(() => Assert.That(actual, AsCollection.Does.Contain(expected)));

			// Assert
			Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsNull(ex);
		}

		[Test]
		public void TestAsCollectionDoesContainFail()
		{
			// Arrange
			var actual = new[] {1, 2, 3, 4};
			const int expected = 5;

			// Act
			var ex = Catch.Exception(() => Assert.That(actual, AsCollection.Does.Contain(expected)));

			// Assert
			Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsInstanceOfType(ex, typeof(AssertFailedException));
		}

		[Test]
		public void TestAsCollectionDoesContainMessage()
		{
			// Arrange
			var actual = new[] {1, 2, 3, 4};
			const int expected = 5;

			// Act
			var ex = Catch.Exception(() => Assert.That(actual, AsCollection.Does.Contain(expected)));

			// Assert
			var expectedMsg = string.Format("AsCollection.Does.Contain({0}) failed.", expected);
			Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(expectedMsg, ex.Message);
			Debug.WriteLine(ex.Message);
		}

		[Test]
		public void TestAsCollectionDoesNotContainPass()
		{
			// Arrange
			var actual = new[] {1, 2, 3, 4};
			const int expected = 5;

			// Act
			var ex = Catch.Exception(() => Assert.That(actual, AsCollection.Does.Not.Contain(expected)));

			// Assert
			Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsNull(ex);
		}

		[Test]
		public void TestAsCollectionDoesNotContainFail()
		{
			// Arrange
			var actual = new[] {1, 2, 3, 4};
			const int expected = 3;

			// Act
			var ex = Catch.Exception(() => Assert.That(actual, AsCollection.Does.Not.Contain(expected)));

			// Assert
			Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsInstanceOfType(ex, typeof(AssertFailedException));
		}

		[Test]
		public void TestAsCollectionDoesNotContainMessage()
		{
			// Arrange
			var actual = new[] {1, 2, 3, 4};
			const int expected = 3;

			// Act
			var ex = Catch.Exception(() => Assert.That(actual, AsCollection.Does.Not.Contain(expected)));

			// Assert
			var expectedMsg = string.Format("Does.Not.Contain({0}) failed.", expected);
			Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(expectedMsg, ex.Message);
			Debug.WriteLine(ex.Message);
		}
	}
}