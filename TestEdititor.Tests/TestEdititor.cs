using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Windows;
using TextEditor;

namespace TestEdititor.Tests
{
    [TestClass]
    public class TestEdititor
    {
        [TestMethod]
        public void TestInsert()
        {
            ClassTextEditor classTextEditor = new ClassTextEditor();

            classTextEditor.Insert("12345");

            Assert.AreEqual("12345", classTextEditor.Text);
        }

        [TestMethod]
        public void TestDelete()
        {
            ClassTextEditor classTextEditor = new ClassTextEditor();
            classTextEditor.Insert("12345");
            classTextEditor.PositionCursor = classTextEditor.PositionCursor - 2;
            
            classTextEditor.Delete();

            Assert.AreEqual("1245", classTextEditor.Text);
        }

        [TestMethod]
        public void TestUndo()
        {
            ClassTextEditor classTextEditor = new ClassTextEditor();
            classTextEditor.Insert("12345");
            classTextEditor.Undo();

            Assert.AreEqual("", classTextEditor.Text);
        }

        [TestMethod]
        public void TestCopy()
        {
            ClassTextEditor classTextEditor = new ClassTextEditor();
            classTextEditor.Insert("new Text");
            for(int i=0;i<4;i++)
                classTextEditor.SelectPositions.SetSelectPositions(classTextEditor.PositionCursor,false);

            classTextEditor.Copy();

            Assert.AreEqual("Text", Clipboard.GetText());
        }

        [TestMethod]
        public void TestPaste()
        {
            ClassTextEditor classTextEditor = new ClassTextEditor();
            classTextEditor.Insert("new");
            Clipboard.Clear();
            Clipboard.SetText(" Text");

            classTextEditor.Paste();

            Assert.AreEqual("new Text", classTextEditor.Text);
        }

        [TestMethod]
        public void TestDidFewAction()
        {
            ClassTextEditor classTextEditor = new ClassTextEditor();
            classTextEditor.Insert("Планета");
            Clipboard.Clear();
            Clipboard.SetText(" Земля");
            classTextEditor.Paste(); // Планета Земля
            //выделяем Землю
            for (int i = 0; i < 5; i++)
                classTextEditor.SelectPositions.SetSelectPositions(classTextEditor.PositionCursor, false);
            //вносим в буфер земля
            classTextEditor.Copy();
            //устанавливаем в 0 - позиция курсора не может быть 0
            classTextEditor.PositionCursor = classTextEditor.PositionCursor - 100;
            classTextEditor.Paste(); // ЗемляПланета Земля
            classTextEditor.Insert(" ");
            classTextEditor.Paste(); // Земля ЗемляПланета Земля
            //отменяем 3 действия
            classTextEditor.Undo(); classTextEditor.Undo(); classTextEditor.Undo(); // _Планета Земля
            //устанавливаем в 0 - позиция курсора не может быть 0
            classTextEditor.PositionCursor = classTextEditor.PositionCursor - 100;
            //Вставляем Марс
            classTextEditor.Insert("Марс "); // Планета Земля
            //устанавливаем в конец текста курсор
            classTextEditor.PositionCursor = classTextEditor.PositionCursor + 100;
            classTextEditor.Insert("2"); //Марс Планета Земля2_


            Assert.AreEqual(true, new Notation("Марс Планета Земля2", "Марс Планета Земля2".Length).Equals(new Notation(classTextEditor.Text,classTextEditor.PositionCursor)));
        }

    }
}
