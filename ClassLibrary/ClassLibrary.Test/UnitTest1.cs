using NUnit.Framework;

namespace ClassLibrary.Test
{
    [TestFixture]
    public class UnitTest1
    {
        [Test]
        public void TestMethod1()
        {
            Library l = new Library();
            Assert.AreEqual(null, l.AllBooks);
        }
    }
}
