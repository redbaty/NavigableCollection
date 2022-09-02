using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NavigableCollection.Tests
{
    [TestClass]
    public class EnumerationTests
    {
        [TestMethod]
        public void TestEnumerable()
        {
            var stringItems = new[]
                {
                    "hello",
                    "world",
                    "!",
                    "a",
                    "b",
                    "c"
                };
            
            var navigableCollection = stringItems
                .ToNavigable()
                .ToArray();
            
            TestCollections(stringItems, navigableCollection);
        }
        
        [TestMethod]
        public async Task TestAsyncEnumerable()
        {
            var stringItems = new[]
            {
                "hello",
                "world",
                "!",
                "a",
                "b",
                "c",
                "d"
            };
            
            var navigableCollection = await stringItems
                .ToAsyncEnumerable()
                .ToNavigable()
                .ToArrayAsync();
            
            TestCollections(stringItems, navigableCollection);
        }

        private static void TestCollections(IReadOnlyList<string> stringItems, IReadOnlyList<NavigableEntry<string>> navigableCollection)
        {
            Assert.AreEqual(stringItems.Count, navigableCollection.Count);

            for (var index = 0; index < navigableCollection.Count; index++)
            {
                var navigableEntry = navigableCollection[index];

                Assert.AreEqual(navigableEntry.Current, stringItems[index]);

                if (index < 2)
                {
                    Assert.AreEqual(navigableEntry.Next, stringItems[index + 1]);
                }

                if (index > 0)
                {
                    Assert.AreEqual(navigableEntry.Previous, stringItems[index - 1]);
                }
            }
        }
    }
}