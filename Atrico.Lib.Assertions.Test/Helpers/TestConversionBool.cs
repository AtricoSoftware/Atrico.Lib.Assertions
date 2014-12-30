﻿using System.Diagnostics;
using Atrico.Lib.Common;
using Atrico.Lib.Testing;
using Atrico.Lib.Testing.NUnitAttributes;

namespace Atrico.Lib.Assertions.Test.Helpers
{
	[TestFixture(typeof (char))]
	[TestFixture(typeof (byte))]
	[TestFixture(typeof (sbyte))]
	[TestFixture(typeof (short))]
	[TestFixture(typeof (ushort))]
	[TestFixture(typeof (int))]
	[TestFixture(typeof (uint))]
	[TestFixture(typeof (long))]
	[TestFixture(typeof (ulong))]
	[TestFixture(typeof (float))]
	[TestFixture(typeof (double))]
	public class TestConversionBool<T> : TestFixtureBase
	{
		[Test]
		public void TestIdentity()
		{
			// Arrange
			var value = RandomValues.Value<T>();

			// Act
			var ex = Catch.Exception(() => Conversion.Convert<bool>(value));

			// Assert
			Assert.That(ex, Is.Not.Null);
			Debug.WriteLine(ex.Message);
		}
	}
}
