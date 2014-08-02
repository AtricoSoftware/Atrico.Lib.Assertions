using System.Diagnostics;
using Atrico.Lib.Testing;
using Atrico.Lib.Testing.NUnitAttributes;

namespace Atrico.Lib.Assertions.Test
{
	[TestFixture]
	public class TestConstantAsserts
	{
		[Test]
		public void TestFail()
		{
			// Arrange

			// Act
			var ex = Catch.Exception(() => Assert.Fail());

			// Assert
			var expectedMsg = string.Format("Failed.");
			Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(expectedMsg, ex.Message);
			Debug.WriteLine(ex.Message);
		}

		[Test]
		public void TestFailMessage()
		{
			// Arrange

			// Act
			var ex = Catch.Exception(() => Assert.Fail("format + {0}", "arg"));

			// Assert
			var expectedMsg = string.Format("Failed. (format + arg)");
			Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(expectedMsg, ex.Message);
			Debug.WriteLine(ex.Message);
		}
	}
}