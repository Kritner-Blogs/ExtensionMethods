using System;
using System.Collections.Generic;
using Xunit;

namespace Kritner.ExtensionMethods.Tests
{
    public class ListExtensionTests
    {
        private class TestClass { }

        #region AddIfNotNull
        [Fact]
        public void ShouldAddItemWhenNotNull()
        {
            var list = new List<TestClass>();
            var notNullItem = new TestClass();

            list.AddIfNotNull(notNullItem);

            Assert.True(list.Count == 1);
        }

        [Fact]
        public void ShouldNotAddItemWhenNull()
        {
            var list = new List<TestClass>();
            TestClass nullItem = null;

            list.AddIfNotNull(nullItem);

            Assert.True(list.Count == 0);
        }

        [Fact]
        public void ShouldThrowIfListIsNull()
        {
            List<TestClass> list = null;
            var item = new TestClass();
            
            Assert.Throws<ArgumentNullException>(() => list.AddIfNotNull(item));
        }
        #endregion AddIfNotNull
    }
}
