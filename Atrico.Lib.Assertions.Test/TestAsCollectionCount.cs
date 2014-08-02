using System.Diagnostics;
using Atrico.Lib.Testing;
using Atrico.Lib.Testing.NUnitAttributes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Atrico.Lib.Assertions.Test
{
	[TestFixture]
	public class TestAsCollectionCount
	{
		[Test]
		public void TestAsCollectionCountEqualToPass()
		{
			// Arrange
			var actual = new[] {1, 2, 3, 4};
			var expected = actual.Length;

			// Act
			var ex = Catch.Exception(() => Assert.That(actual, AsCollection.Count.Is.EqualTo(expected)));

			// Assert
			Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsNull(ex);
		}

		[Test]
		public void TestAsCollectionCountEqualToFail()
		{
			// Arrange
			var actual = new[] {1, 2, 3, 4};
			var expected = actual.Length+1;

			// Act
			var ex = Catch.Exception(() => Assert.That(actual, AsCollection.Count.Is.EqualTo(expected)));

			// Assert
			Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsInstanceOfType(ex, typeof(AssertFailedException));
		}

		[Test]
		public void TestAsCollectionCountEqualToMessage()
		{
			// Arrange
			var actual = new[] {1, 2, 3, 4};
			var expected = actual.Length+1;

			// Act
			var ex = Catch.Exception(() => Assert.That(actual, AsCollection.Count.Is.EqualTo(expected)));

			// Assert
			var expectedMsg = string.Format("AsCollection.Count.Is.EqualTo failed. Expected:<{0}>, Actual:<{1}>", expected,
				actual.Length);
			Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(expectedMsg, ex.Message);
			Debug.WriteLine(ex.Message);
		}

		[Test]
		public void TestAsCollectionCountNotEqualToPass()
		{
			// Arrange
			var actual = new[] {1, 2, 3, 4};
			var expected = actual.Length+1;

			// Act
			var ex = Catch.Exception(() => Assert.That(actual, AsCollection.Count.Is.Not.EqualTo(expected)));

			// Assert
			Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsNull(ex);
		}

		[Test]
		public void TestAsCollectionCountNotEqualToFail()
		{
			// Arrange
			var actual = new[] {1, 2, 3, 4};
			var expected = actual.Length;

			// Act
			var ex = Catch.Exception(() => Assert.That(actual, AsCollection.Count.Is.Not.EqualTo(expected)));

			// Assert
			Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsInstanceOfType(ex, typeof(AssertFailedException));
		}

		[Test]
		public void TestAsCollectionCountNotEqualToMessage()
		{
			// Arrange
			var actual = new[] {1, 2, 3, 4};
			var expected = actual.Length;

			// Act
			var ex = Catch.Exception(() => Assert.That(actual, AsCollection.Count.Is.Not.EqualTo(expected)));

			// Assert
			var expectedMsg = string.Format("AsCollection.Count.Is.Not.EqualTo failed. Expected:<{0}>, Actual:<{1}>", expected,
				actual.Length);
			Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(expectedMsg, ex.Message);
			Debug.WriteLine(ex.Message);
		}

		[Test]
		public void TestAsCollectionCountSatisfyPass()
		{
			// Arrange
			var actual = new[] {1, 2, 3, 4};
			var expected = actual.Length;

			// Act
			var ex = Catch.Exception(() => Assert.That(actual, AsCollection.Count.Does.Satisfy.Predicate<int>(a => a == expected)));

			// Assert
			Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsNull(ex);
		}

		[Test]
		public void TestAsCollectionCountSatisfyFail()
		{
			// Arrange
			var actual = new[] {1, 2, 3, 4};
			var expected = actual.Length+1;

			// Act
			var ex = Catch.Exception(() => Assert.That(actual, AsCollection.Count.Does.Satisfy.Predicate<int>(a => a == expected)));

			// Assert
			Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsInstanceOfType(ex, typeof(AssertFailedException));
		}

		[Test]
		public void TestAsCollectionCountSatisfyMessage()
		{
			// Arrange
			var actual = new[] {1, 2, 3, 4};
			var expected = actual.Length+1;

			// Act
			var ex = Catch.Exception(() => Assert.That(actual, AsCollection.Count.Does.Satisfy.Predicate<int>(a => a == expected)));

			// Assert
			var expectedMsg = string.Format("AsCollection.Count.Does.Satisfy.Predicate failed. Subject:<{0}>", actual.Length);
			Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(expectedMsg, ex.Message);
			Debug.WriteLine(ex.Message);
		}
	}
}