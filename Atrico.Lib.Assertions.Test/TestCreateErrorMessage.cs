using System.Collections.Generic;
using System.Text;
using Atrico.Lib.Assertions.Constraints;
using Atrico.Lib.Assertions.Elements;
using Atrico.Lib.Testing.NUnitAttributes;

namespace Atrico.Lib.Assertions.Test
{
    [TestFixture]
    public class TestCreateErrorMessage
    {
        [Test]
        public void TestCreateErrorMessageInt()
        {
            // Arrange
            const int actual = 1;
            const int expected = 2;
            var constraint = Value.Of(actual).Is().EqualTo(expected);

            // Act
            var msg = constraint.ErrorMessage;

            // Assert
            var expectedMsg = string.Format("Expected:<{0}>, Actual:<{1}>", expected, actual);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(expectedMsg, msg);
        }

        [Test]
        public void TestCreateErrorMessageArray()
        {
            // Arrange
            var actual = new[] {1, 2, 3};
            var expected = new[] {1, 2, 3, 4};
            var constraint = Value.Of(actual).Is().EqualTo(expected);

            // Act
            var msg = constraint.ErrorMessage;

            // Assert
            var expectedMsg = string.Format("Expected:<{0}>, Actual:<{1}>: Count<-1>, Missing<[4]>", FormatList(expected), FormatList(actual));
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(expectedMsg, msg);
        }

        [Test]
        public void TestCreateErrorMessageList()
        {
            // Arrange
            var actual = new List<int> {1, 2, 3, 4};
            var expected = new[] {1, 2, 3};
            var constraint = Value.Of(actual).Is().EqualTo(expected);

            // Act
            var msg = constraint.ErrorMessage;

            // Assert
            var expectedMsg = string.Format("Expected:<{0}>, Actual:<{1}>: Count<+1>, Extra<[4]>", FormatList(expected), FormatList(actual));
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(expectedMsg, msg);
        }

        [Test]
        public void TestCreateErrorMessageString()
        {
            // Arrange
            const string actual = "hello";
            const string expected = "world";
            var constraint = Value.Of(actual).Is().EqualTo(expected);

            // Act
            var msg = constraint.ErrorMessage;

            // Assert
            var expectedMsg = string.Format("Expected:<{0}>, Actual:<{1}>", expected, actual);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(expectedMsg, msg);
        }

        private static string FormatList(IEnumerable<int> list)
        {
            var text = new StringBuilder();
            var sep = '[';
            foreach (var item in list)
            {
                text.Append(sep);
                text.Append(item);
                sep = ',';
            }
            text.Append(']');
            return text.ToString();
        }
    }
}