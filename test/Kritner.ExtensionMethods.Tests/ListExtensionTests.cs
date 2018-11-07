using System;
using System.Collections.Generic;
using Xunit;

namespace Kritner.ExtensionMethods.Tests
{
    public class ListExtensionTests
    {
        public class TestClass { }

        #region AddIfNotNull
        [Fact]
        public void AddIfNotNull_ShouldAddItemWhenNotNull()
        {
            var list = new List<TestClass>();
            var notNullItem = new TestClass();

            list.AddIfNotNull(notNullItem);

            Assert.True(list.Count == 1);
        }

        [Fact]
        public void AddIfNotNull_ShouldNotAddItemWhenNull()
        {
            var list = new List<TestClass>();
            TestClass nullItem = null;

            list.AddIfNotNull(nullItem);

            Assert.True(list.Count == 0);
        }

        [Fact]
        public void AddIfNotNull_ShouldThrowIfListIsNull()
        {
            List<TestClass> list = null;
            var item = new TestClass();
            
            Assert.Throws<ArgumentNullException>(() => list.AddIfNotNull(item));
        }
        #endregion AddIfNotNull

        #region AddRangeIfNotNull
        public static IEnumerable<object[]> AddRangeSuccessMultipleType =>
            new List<object[]>()
            {
                new object[]
                {
                    new TestClass[] { new TestClass(), }, 1
                },
                new object[] 
                {
                    new TestClass[] { new TestClass(), new TestClass() }, 2
                },
                new object[]
                {
                    new List<TestClass> { new TestClass(), }, 1
                },
                new object[]
                {
                    new List<TestClass> { new TestClass(), new TestClass() }, 2
                }
            };

        [Theory]
        [MemberData(nameof(AddRangeSuccessMultipleType))]
        public void AddRangeIfNotNull_ShouldAddItemsWhenNotNull(
            IEnumerable<TestClass> testData, 
            int numberOfElementsToAdd
        )
        {
            var list = new List<TestClass>();

            list.AddRangeIfNotNull(testData);

            Assert.Equal(numberOfElementsToAdd, list.Count);
        }

        public static IEnumerable<object[]> AddRangeNoItemsMultipleType =>
            new List<object[]>()
            {
                new object[]
                {
                    new TestClass[] { }
                },
                new object[]
                {
                    null
                },
                new object[]
                {
                    new List<TestClass> ()
                }
            };

        [Theory]
        [MemberData(nameof(AddRangeNoItemsMultipleType))]
        public void AddRangeIfNotNull_ShouldNotAddItemsWhenNoItemsToAdd(IEnumerable<TestClass> testData)
        {
            var list = new List<TestClass>();

            list.AddRangeIfNotNull(testData);

            Assert.Empty(list);
        }

        [Fact]
        public void AddRangeIfNotNull_ShouldThrowIfListIsNull()
        {
            List<TestClass> list = null;
            var item = new TestClass();

            Assert.Throws<ArgumentNullException>(
                () => list.AddRangeIfNotNull(new[] { item })
            );
        }
        #endregion AddRangeIfNotNull
    }
}
