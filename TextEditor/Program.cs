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

                if (classTextEditor.Main(key))
                {
                    if (classTextEditor.SelectPositions.Select) SelectText();
                    else UpdateText();
                }
                else break;
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
