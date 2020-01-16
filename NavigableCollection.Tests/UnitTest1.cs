using System;
using JetBrains.dotMemoryUnit;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NavigableCollection.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            dotMemory.Check();
            var stringItems = new[]
            {
                    "hello",
                    "world",
                    "!"
            };
            var navigableCollection = new Navigable<string>(stringItems);

            dotMemory.Check(memory =>
            {
                var objectSet = memory.GetObjects(where => where.Type.Is<NavigableEntry<string>>());

                Console.WriteLine("{0} objects found, with a total size of {1}",
                        objectSet.ObjectsCount,
                        objectSet.SizeInBytes);

                Console.WriteLine("Total size of: {0}", FileSizeHelper.GetHumanReadableFileSize(memory.SizeInBytes));
            });

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