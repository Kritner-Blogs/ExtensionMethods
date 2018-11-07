using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Kritner.ExtensionMethods.Tests
{
    public class EnumerableExtensionTests
    {
        public class EnumerableTest
        {
            public int SomeInt { get; set; }
        }

        public static List<object[]> EnumerableTestData =>
            new List<object[]>()
            {
                new object[]
                {
                    new List<EnumerableTest>()
                    {
                        new EnumerableTest() { SomeInt = 1 },
                        new EnumerableTest() { SomeInt = 42 },
                    }
                }
            };

        [Fact]
        public void ShouldThrowWhenItemsNull()
        {
            List<EnumerableTest> items = null;

            Assert.Throws<ArgumentNullException>(() => 
                items.TryFirst(t => t.SomeInt == 42, out var result)
            );
        }

        [Theory]
        [MemberData(nameof(EnumerableTestData))]
        public void ShouldThrowWhenPredicateNull(List<EnumerableTest> items)
        {
            Assert.Throws<ArgumentNullException>(() =>
                items.TryFirst(null, out var result)
            );
        }

        [Theory]
        [MemberData(nameof(EnumerableTestData))]
        public void ShouldReturnFalseWhenDataNotFound(List<EnumerableTest> items)
        {
            var found = items.TryFirst(
                t => t.SomeInt == 100, out var result
            );

            Assert.False(found);
        }

        [Theory]
        [MemberData(nameof(EnumerableTestData))]
        public void ShouldReturnTrueWhenDataFound(List<EnumerableTest> items)
        {
            var found = items.TryFirst(
                t => t.SomeInt == 42, out var result
            );

            Assert.True(found);
        }

        [Theory]
        [MemberData(nameof(EnumerableTestData))]
        public void ShouldReturnDataWhenDataFound(List<EnumerableTest> items)
        {
            var dataToSearch = 42;

            var found = items.TryFirst(
                t => t.SomeInt == dataToSearch, out var result
            );

            Assert.Equal(dataToSearch, result.SomeInt);
        }
    }
}
