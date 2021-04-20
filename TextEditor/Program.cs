using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace TextEditor
{
    class Program
    {
            static ClassTextEditor classTextEditor = new ClassTextEditor();

            [STAThreadAttribute]
            static void Main(string[] args)
             {

            Console.TreatControlCAsInput = true;
            Console.WriteLine("esc = exit, ctr+z = undo, ctr+left(or Right) = select, ctrl+C = Copy, ctr+V = Insert, del (or Backspace) = del");
            ConsoleKeyInfo key;

            while (true)
            {
                key = Console.ReadKey(true);

                if (key.Key == ConsoleKey.Escape)
                {
                    break;
                }

                //вставка ctrl+c
                if (key.Modifiers == ConsoleModifiers.Control && key.Key == ConsoleKey.C&& classTextEditor.SelectPositions.Select)
                {
                    classTextEditor.Copy();
                    UpdateText();
                    continue;
                }

                //вставка ctrl+V
                if (key.Modifiers ==ConsoleModifiers.Control&& key.Key == ConsoleKey.V)
                {
                    classTextEditor.Paste();
                    UpdateText();
                    continue;
                }

                //press ctrl+z
                if (key.Modifiers == ConsoleModifiers.Control && key.Key == ConsoleKey.Z)
                {
                    classTextEditor.Undo();
                    UpdateText();
                    continue;
                }

                //press shift+left(+rigth)
                if (key.Modifiers == ConsoleModifiers.Shift && key.Key == ConsoleKey.LeftArrow)
                    classTextEditor.SelectPositions.SetSelectPositions(classTextEditor.PositionCursor, false);
                else if (key.Modifiers == ConsoleModifiers.Shift && key.Key == ConsoleKey.RightArrow)
                    classTextEditor.SelectPositions.SetSelectPositions(classTextEditor.PositionCursor, true);

                //cancel selected
                if (key.Key == ConsoleKey.Insert) classTextEditor.SelectPositions.CancelSelect();

                if (classTextEditor.SelectPositions.Select)
                {
                    SelectText();
                    continue;
                }
                else if (key.Modifiers == ConsoleModifiers.Shift &&
                         (key.Key == ConsoleKey.LeftArrow || key.Key == ConsoleKey.RightArrow))
                {
                    UpdateText();
                    continue;
                }

                //press button left or Rigth
                if (key.Key == ConsoleKey.LeftArrow)
                {
                    classTextEditor.PositionCursor--;
                    Console.SetCursorPosition(classTextEditor.PositionCursor, 1);
                    continue;
                }
                else if (key.Key == ConsoleKey.RightArrow)
                {
                    classTextEditor.PositionCursor++;
                    Console.SetCursorPosition(classTextEditor.PositionCursor, 1);
                    continue;
                }

                //press backspace or del
                if (key.Key == ConsoleKey.Backspace | key.Key == ConsoleKey.Delete)
                {
                    classTextEditor.Delete();
                    UpdateText();
                    continue;
                }

                if (key.KeyChar == '\u0000') continue;
                else
                {
                   classTextEditor.Insert(key.KeyChar.ToString());
                   UpdateText();
                }


                
            }
        }

            private static void UpdateText()
            {
            Console.SetCursorPosition(0, 1);
            Console.Write(new String(' ', Console.BufferWidth));
            Console.SetCursorPosition(0, 1);
            Console.Write(classTextEditor.Text);
            Console.SetCursorPosition(classTextEditor.PositionCursor, 1);
            }

            private static void SelectText()
            {
                int startIndex= classTextEditor.SelectPositions.GetFistIndexSelect(),finishIndex = classTextEditor.SelectPositions.GetLastIndexSelect();
                Console.SetCursorPosition(0, 1);
                int index = 0;
                foreach (var ch in classTextEditor.Text)
                {
                    if (index >= startIndex && index < finishIndex)
                    {
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.BackgroundColor = ConsoleColor.White;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.BackgroundColor = ConsoleColor.Black;
                    }

                    index++;
                    Console.Write(ch);
                }
            Console.SetCursorPosition(classTextEditor.PositionCursor, 1);
        }

    }
}
