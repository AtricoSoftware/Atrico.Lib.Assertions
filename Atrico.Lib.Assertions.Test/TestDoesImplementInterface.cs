using System.Diagnostics;
using Atrico.Lib.Testing;
using Atrico.Lib.Testing.NUnitAttributes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Atrico.Lib.Assertions.Test
{
	[TestFixture]
	public class TestDoesImplementInterface
	{
		private interface INot
		{
		}

		private interface IBase
		{
		}

		private interface IDerived : IBase
		{
		}

		private class Base : IBase
		{
		}

		private class Derived : IDerived
		{
		}

		[Test]
		public void TestDoesImplementInterfaceSimplePass()
		{
			// Arrange
			var actual = new Base();

			// Act
			var ex = Catch.Exception(() => Assert.That(actual, Does.Implement.Interface(typeof (IBase))));

			// Assert
			Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsNull(ex);
		}

		[Test]
		public void TestDoesImplementInterfaceDerivedPass()
		{
			// Arrange
			var actual = new Derived();

			// Act
			var ex = Catch.Exception(() => Assert.That(actual, Does.Implement.Interface(typeof (IBase))));

			// Assert
			Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsNull(ex);
		}

		[Test]
		public void TestDoesImplementInterfaceFail()
		{
			// Arrange
			var actual = new Base();

			// Act
			var ex = Catch.Exception(() => Assert.That(actual, Does.Implement.Interface(typeof (INot))));

			// Assert
			Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsInstanceOfType(ex, typeof (AssertFailedException));
		}

		[Test]
		public void TestDoesImplementInterfaceMessage()
		{
			// Arrange
			var actual = new Base();

			// Act
			var ex = Catch.Exception(() => Assert.That(actual, Does.Implement.Interface(typeof (INot))));

			// Assert
			var expectedMsg = string.Format("Does.Implement.Interface<{0}> failed.", typeof (INot));
			Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(expectedMsg, ex.Message);
			Debug.WriteLine(ex.Message);
		}

		[Test]
		public void TestDoesImplementInterfaceGenericSimplePass()
		{
			// Arrange
			var actual = new Base();

			// Act
			var ex = Catch.Exception(() => Assert.That(actual, Does.Implement.Interface<IBase>()));

			// Assert
			Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsNull(ex);
		}

		[Test]
		public void TestDoesImplementInterfaceGenericDerivedPass()
		{
			// Arrange
			var actual = new Derived();

			// Act
			var ex = Catch.Exception(() => Assert.That(actual, Does.Implement.Interface<IBase>()));

			// Assert
			Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsNull(ex);
		}

		[Test]
		public void TestDoesImplementInterfaceGenericFail()
		{
			// Arrange
			var actual = new Base();

			// Act
			var ex = Catch.Exception(() => Assert.That(actual, Does.Implement.Interface<INot>()));

			// Assert
			Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsInstanceOfType(ex, typeof (AssertFailedException));
		}

		[Test]
		public void TestDoesImplementInterfaceGenericMessage()
		{
			// Arrange
			var actual = new Base();

			// Act
			var ex = Catch.Exception(() => Assert.That(actual, Does.Implement.Interface<INot>()));

			// Assert
			var expectedMsg = string.Format("Does.Implement.Interface<{0}> failed.", typeof (INot));
			Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(expectedMsg, ex.Message);
			Debug.WriteLine(ex.Message);
		}

		[Test]
		public void TestDoesNotImplementInterfaceSimpleFail()
		{
			// Arrange
			var actual = new Base();

			// Act
			var ex = Catch.Exception(() => Assert.That(actual, Does.Not.Implement.Interface(typeof (IBase))));

			// Assert
			Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsInstanceOfType(ex, typeof (AssertFailedException));
		}

		[Test]
		public void TestDoesNotImplementInterfaceDerivedFail()
		{
			// Arrange
			var actual = new Derived();

			// Act
			var ex = Catch.Exception(() => Assert.That(actual, Does.Not.Implement.Interface(typeof (IBase))));

			// Assert
			Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsInstanceOfType(ex, typeof (AssertFailedException));
		}

		[Test]
		public void TestDoesNotImplementInterfacePass()
		{
			// Arrange
			var actual = new Base();

			// Act
			var ex = Catch.Exception(() => Assert.That(actual, Does.Not.Implement.Interface(typeof (INot))));

			// Assert
			Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsNull(ex);
		}

		[Test]
		public void TestDoesNotImplementInterfaceMessage()
		{
			// Arrange
			var actual = new Base();

			// Act
			var ex = Catch.Exception(() => Assert.That(actual, Does.Not.Implement.Interface(typeof (IBase))));

			// Assert
			var expectedMsg = string.Format("Does.Not.Implement.Interface<{0}> failed.", typeof (IBase));
			Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(expectedMsg, ex.Message);
			Debug.WriteLine(ex.Message);
		}

		[Test]
		public void TestDoesNotImplementInterfaceGenericSimpleFail()
		{
			// Arrange
			var actual = new Base();

			// Act
			var ex = Catch.Exception(() => Assert.That(actual, Does.Not.Implement.Interface<IBase>()));

			// Assert
			Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsInstanceOfType(ex, typeof (AssertFailedException));
		}

		[Test]
		public void TestDoesNotImplementInterfaceGenericDerivedFail()
		{
			// Arrange
			var actual = new Derived();

			// Act
			var ex = Catch.Exception(() => Assert.That(actual, Does.Not.Implement.Interface<IBase>()));

			// Assert
			Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsInstanceOfType(ex, typeof (AssertFailedException));
		}

		[Test]
		public void TestDoesNotImplementInterfaceGenericPass()
		{
			// Arrange
			var actual = new Base();

			// Act
			var ex = Catch.Exception(() => Assert.That(actual, Does.Not.Implement.Interface<INot>()));

			// Assert
			Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsNull(ex);
		}

		[Test]
		public void TestDoesNotImplementInterfaceGenericMessage()
		{
			// Arrange
			var actual = new Base();

			// Act
			var ex = Catch.Exception(() => Assert.That(actual, Does.Not.Implement.Interface<IBase>()));

			// Assert
			var expectedMsg = string.Format("Does.Not.Implement.Interface<{0}> failed.", typeof (IBase));
			Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(expectedMsg, ex.Message);
			Debug.WriteLine(ex.Message);
		}
	}
}
