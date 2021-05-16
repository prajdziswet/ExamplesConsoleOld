using System;
using NUnit.Framework;
using Shouldly;

namespace ClassLibrary.Test
{
    [TestFixture]
    public class TestDepartmentReaders
    {
        [Test]
        public void Add_NullReader()
        {
            DepartmentReaders DR = new DepartmentReaders();
            Should.Throw<ArgumentNullException>(() => DR.AddReader(null));
        }

        [Test]
        public void AddReader()
        {
            DepartmentReaders DR = new DepartmentReaders();
            Reader reader = new Reader("Lev", "Tolstoj");
            DR.AddReader(reader);

            Reader gotReader = DR.GetReader(reader.ID);
            gotReader.ShouldBe(reader);
        }

        [Test]
        public void AddEqualReaders()
        {
            DepartmentReaders DR = new DepartmentReaders();
            Reader reader = new Reader("Lev", "Tolstoj");
            DR.AddReader(reader);

            Should.Throw<ArgumentException>(() => DR.AddReader(reader));
        }

        [Test]
        public void ReturnNotReader()
        {
            DepartmentReaders DR = new DepartmentReaders();
            DR.GetReader(0).ShouldBe(null);
        }
    }
}