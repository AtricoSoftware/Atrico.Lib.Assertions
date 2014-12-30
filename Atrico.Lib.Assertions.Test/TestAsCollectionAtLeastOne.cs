using System.Diagnostics;
using Atrico.Lib.Testing;
using Atrico.Lib.Testing.NUnitAttributes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Atrico.Lib.Assertions.Test
{
	[TestFixture]
	public class TestAsCollectionAtLeastOne
	{
		[Test]
		public void TestAsCollectionAtLeastOneIsBetweenPass()
		{
			// Arrange
			var actual = new[] {1, 2, 3, 4};
			const int lowerLimit = 3;
			const int upperLimit = 4;

			// Act
			var ex = Catch.Exception(() => Assert.That(actual, AsCollection.AtLeastOne.Is.Between(lowerLimit, upperLimit)));

			// Assert
			Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsNull(ex);
		}

		[Test]
		public void TestAsCollectionAtLeastOneIsBetweenFail()
		{
			// Arrange
			var actual = new[] {1, 2, 3, 4};
			const int lowerLimit = 6;
			const int upperLimit = 7;

			// Act
			var ex = Catch.Exception(() => Assert.That(actual, AsCollection.AtLeastOne.Is.Between(lowerLimit, upperLimit)));

			// Assert
			Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsInstanceOfType(ex, typeof (AssertFailedException));
		}

		[Test]
		public void TestAsCollectionAtLeastOneIsBetweenMessage()
		{
			// Arrange
			var actual = new[] {1, 2, 3, 4};
			const int lowerLimit = 6;
			const int upperLimit = 7;

			// Act
			var ex = Catch.Exception(() => Assert.That(actual, AsCollection.AtLeastOne.Is.Between(lowerLimit, upperLimit)));

			// Assert
			var expectedMsg = string.Format("AsCollection.AtLeastOne.Is.Between({0} -> {1}) failed. Actual:<[1,2,3,4]>", lowerLimit,
			                                upperLimit);
			Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(expectedMsg, ex.Message);
			Debug.WriteLine(ex.Message);
		}

		[Test]
		public void TestAsCollectionAtLeastOneIsNotBetweenPass()
		{
			// Arrange
			var actual = new[] {1, 2, 3, 4};
			const int lowerLimit = 2;
			const int upperLimit = 4;

			// Act
			var ex = Catch.Exception(() => Assert.That(actual, AsCollection.AtLeastOne.Is.Not.Between(lowerLimit, upperLimit)));

			// Assert
			Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsNull(ex);
		}

		[Test]
		public void TestAsCollectionAtLeastOneIsNotBetweenFail()
		{
			// Arrange
			var actual = new[] {1, 2, 3, 4};
			const int lowerLimit = 1;
			const int upperLimit = 4;

			// Act
			var ex = Catch.Exception(() => Assert.That(actual, AsCollection.AtLeastOne.Is.Not.Between(lowerLimit, upperLimit)));

			// Assert
			Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsInstanceOfType(ex, typeof (AssertFailedException));
		}

		[Test]
		public void TestAsCollectionAtLeastOnetIsNotBetweenMessage()
		{
			// Arrange
			var actual = new[] {1, 2, 3, 4};
			const int lowerLimit = 1;
			const int upperLimit = 4;

			// Act
			var ex = Catch.Exception(() => Assert.That(actual, AsCollection.AtLeastOne.Is.Not.Between(lowerLimit, upperLimit)));

			// Assert
			var expectedMsg = string.Format("AsCollection.AtLeastOne.Is.Not.Between({0} -> {1}) failed. Actual:<[1,2,3,4]>",
			                                lowerLimit, upperLimit);
			Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(expectedMsg, ex.Message);
			Debug.WriteLine(ex.Message);
		}
	}
}
