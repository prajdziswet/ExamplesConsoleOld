using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ClassLibrary.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Library l = new Library();
            Assert.AreEqual(null, l.AllBooks);
        }
    }
}
