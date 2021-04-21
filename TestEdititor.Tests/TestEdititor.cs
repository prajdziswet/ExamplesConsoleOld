using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Windows;
using TextEditor;

namespace TestEdititor.Tests
{
    [TestClass]
    public class TestEdititor
    {
        private void Insert(ClassTextEditor classTextEditor)
        {
            Clipboard.Clear();
            Clipboard.SetText(" Text");
            ConsoleKeyInfo key = new ConsoleKeyInfo('V', ConsoleKey.V, false, false, true);
            classTextEditor.Main(key);
        }

        [TestMethod]
        //check Insert
        public void TestInsert()
        {
            ClassTextEditor classTextEditor = new ClassTextEditor();

            ConsoleKeyInfo key = new ConsoleKeyInfo('T',ConsoleKey.T, false, false, false);
            classTextEditor.Main(key);
            key = new ConsoleKeyInfo('e', ConsoleKey.E, false, false, false);
            classTextEditor.Main(key);
            key = new ConsoleKeyInfo('x', ConsoleKey.X, false, false, false);
            classTextEditor.Main(key);
            key = new ConsoleKeyInfo('t', ConsoleKey.T, false, false, false);
            classTextEditor.Main(key);

            Assert.AreEqual("Text", classTextEditor.Text);
        }

        [TestMethod]
        //check ctrl+v or Paste
        public void TestPaste()
        {
            ClassTextEditor classTextEditor = new ClassTextEditor();
            Insert(classTextEditor);

            Assert.AreEqual(" Text", classTextEditor.Text);
        }

        [TestMethod]
        //check backspase and delete or Delete
        public void TestDelete()
        {
            ClassTextEditor classTextEditor = new ClassTextEditor();

            Insert(classTextEditor);
            ConsoleKeyInfo key = new ConsoleKeyInfo('\0', ConsoleKey.Delete, false, false, false);
            classTextEditor.Main(key);
            key = new ConsoleKeyInfo('\0', ConsoleKey.Backspace, false, false, false);
            classTextEditor.Main(key);

            Assert.AreEqual(" Te", classTextEditor.Text);
        }

        [TestMethod]
        //check ctrl+Z or Undo
        public void TestUndo()
        {
            ClassTextEditor classTextEditor = new ClassTextEditor();

            Insert(classTextEditor);
            ConsoleKeyInfo key = new ConsoleKeyInfo('Z', ConsoleKey.Z, false, false, true);
            classTextEditor.Main(key);

            Assert.AreEqual("", classTextEditor.Text);
        }

        [TestMethod]
        //check ctrl+C or Copy
        public void TestCopy()
        {
            ClassTextEditor classTextEditor = new ClassTextEditor();

            Insert(classTextEditor);
            ConsoleKeyInfo key = new ConsoleKeyInfo('C', ConsoleKey.C, false, false, true);
            classTextEditor.Main(key);

            Assert.AreEqual(" Text", Clipboard.GetText());
        }

        [TestMethod]
        //Check escape
        public void TestEscape()
        {
            ClassTextEditor classTextEditor = new ClassTextEditor();
            ConsoleKeyInfo key = new ConsoleKeyInfo('\0', ConsoleKey.Escape, false, false, false);

            Assert.AreEqual(false, classTextEditor.Main(key));
        }

        [TestMethod]
        //Check button left and right
        public void TestLeftAndRight()
        {
            ClassTextEditor classTextEditor = new ClassTextEditor();
            Insert(classTextEditor);// " Text"
            ConsoleKeyInfo key = new ConsoleKeyInfo('\0', ConsoleKey.LeftArrow ,false, false, false);
            classTextEditor.Main(key);
            classTextEditor.Main(key);
            key = new ConsoleKeyInfo('\0', ConsoleKey.RightArrow, false, false, false);
            classTextEditor.Main(key);

            Assert.AreEqual(4, classTextEditor.PositionCursor);
        }

        [TestMethod]
        //Check button "Shift + left or right" or Select
        public void TestSelect()
        {
            ClassTextEditor classTextEditor = new ClassTextEditor();
            Insert(classTextEditor);// " Text"
            ConsoleKeyInfo key = new ConsoleKeyInfo('\0', ConsoleKey.LeftArrow, true, false, false);
            classTextEditor.Main(key);
            classTextEditor.Main(key);
            key = new ConsoleKeyInfo('\0', ConsoleKey.RightArrow, true, false, false);
            classTextEditor.Main(key);

            Assert.AreEqual(true, classTextEditor.SelectPositions.GetFistIndexSelect()==4&& classTextEditor.SelectPositions.GetLastIndexSelect() == 5);
        }

    }
}
