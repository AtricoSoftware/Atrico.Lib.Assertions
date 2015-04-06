using System.Diagnostics;
using Atrico.Lib.Assertions.Constraints;
using Atrico.Lib.Assertions.Elements;
using Atrico.Lib.Testing;
using Atrico.Lib.Testing.NUnitAttributes;

namespace Atrico.Lib.Assertions.Test
{
    [TestFixture]
    public class TestFormattedMessage
    {
        [Test]
        public void TestMessageWithArgs()
        {
            // Arrange

            // Act
            var ex = Catch.Exception(() => Assert.That(Value.Of(false).Is().True(), "args = {0},{1},{2}", "one", 2, "three"));

            // Assert
            var expectedMsg = string.Format("Is.True failed. (args = one,2,three)");
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(expectedMsg, ex.Message);
            Debug.WriteLine(ex.Message);
        }
    }
}