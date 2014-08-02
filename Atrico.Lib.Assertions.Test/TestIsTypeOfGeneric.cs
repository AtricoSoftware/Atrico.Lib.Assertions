using System.Diagnostics;
using Atrico.Lib.Testing;
using Atrico.Lib.Testing.NUnitAttributes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Atrico.Lib.Assertions.Test
{
	[TestFixture]
	public class TestIsTypeOfGeneric
	{
		[Test]
		public void TestTypeOfGenericPass()
		{
			// Arrange
			const double actual = 1;

			// Act
			var ex = Catch.Exception(() => Assert.That(actual, Is.TypeOf<double>()));

			// Assert
			Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsNull(ex);
		}

		[Test]
		public void TestTypeOfGenericFail()
		{
			// Arrange
			const int actual = 1;

			// Act
			var ex = Catch.Exception(() => Assert.That(actual, Is.TypeOf<float>()));

			// Assert
			Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsInstanceOfType(ex, typeof(AssertFailedException));
		}

		[Test]
		public void TestIsTypeOfGenericMessage()
		{
			// Arrange
			const int actual = 1;
			var expected = typeof(float);

			// Act
			var ex = Catch.Exception(() => Assert.That(actual, Is.TypeOf<float>()));

			// Assert
			var expectedMsg = string.Format("Is.TypeOf<{0}> failed. Actual:<{1}>", expected, actual.GetType());
			Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(expectedMsg, ex.Message);
			Debug.WriteLine(ex.Message);
		}

		[Test]
		public void TestNotTypeOfGenericPass()
		{
			// Arrange
			const double actual = 1;

			// Act
			var ex = Catch.Exception(() => Assert.That(actual, Is.Not.TypeOf<float>()));

			// Assert
			Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsNull(ex);
		}

		[Test]
		public void TestNotTypeOfGenericFail()
		{
			// Arrange
			const int actual = 1;

			// Act
			var ex = Catch.Exception(() => Assert.That(actual, Is.Not.TypeOf<int>()));

			// Assert
			Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsInstanceOfType(ex, typeof(AssertFailedException));
		}

		[Test]
		public void TestIsNotTypeOfGenericMessage()
		{
			// Arrange
			const int actual = 1;
			var expected = typeof(int);

			// Act
			var ex = Catch.Exception(() => Assert.That(actual, Is.Not.TypeOf<int>()));

			// Assert
			var expectedMsg = string.Format("Is.Not.TypeOf<{0}> failed. Actual:<{1}>", expected, actual.GetType());
			Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(expectedMsg, ex.Message);
			Debug.WriteLine(ex.Message);
		}
	}
}