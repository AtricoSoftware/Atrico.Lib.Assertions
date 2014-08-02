using System.Collections;
using System.Collections.Generic;
using Atrico.Lib.Testing;
using Atrico.Lib.Testing.NUnitAttributes;

namespace Atrico.Lib.Assertions.Test
{
	[TestFixture(typeof(int), new[] {1, 2, 3, 4})]
	[TestFixture(typeof(float), new[] {1f, 2f, 3f, 4f})]
	[TestFixture(typeof(string), new[] {"1", "2", "3", "4"})]
	public class TestAsCollectionT<T>
	{
		private readonly T[] _list;
		private readonly T[] _listCopy;

		/// <summary>
		/// Constructor
		/// </summary>
		public TestAsCollectionT(T[] list)
		{
			_list = list;
			_listCopy = new T[list.Length];
			_list.CopyTo(_listCopy, 0);
		}

		[Test]
		public void TestAsCollectionTArrayEqualToArray()
		{
			// Arrange
			var actual = _list;
			var expected = _listCopy;

			// Act
			var ex = Catch.Exception(() => Assert.That(actual, AsCollection<T>.Is.EqualTo(expected)));

			// Assert
			Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsNull(ex);
		}

		[Test]
		public void TestAsCollectionTListEqualToArray()
		{
			// Arrange
			var actual = new List<T>(_list);
			var expected = _listCopy;

			// Act
			var ex = Catch.Exception(() => Assert.That(actual, AsCollection<T>.Is.EqualTo(expected)));

			// Assert
			Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsNull(ex);
		}

		[Test]
		public void TestAsCollectionTArrayEqualToList()
		{
			// Arrange
			var actual = _list;
			var expected = new List<T>(_listCopy);

			// Act
			var ex = Catch.Exception(() => Assert.That(actual, AsCollection<T>.Is.EqualTo(expected)));

			// Assert
			Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsNull(ex);
		}

		[Test]
		public void TestAsCollectionTObjectEqualToArray()
		{
			// Arrange
			var actual = new CustomObject(_list);
			var expected = _listCopy;

			// Act
			var ex = Catch.Exception(() => Assert.That(actual, AsCollection<T>.Is.EqualTo(expected)));

			// Assert
			Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsNull(ex);
		}

		private class CustomObject : IEnumerable<T>
		{
			private readonly List<T> _list;

			public CustomObject(IEnumerable<T> ints)
			{
				_list = new List<T>(ints);
			}

			public IEnumerator<T> GetEnumerator()
			{
				return _list.GetEnumerator();
			}

			IEnumerator IEnumerable.GetEnumerator()
			{
				return GetEnumerator();
			}
		}
	}
}