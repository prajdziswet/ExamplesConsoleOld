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
            //select
            bool sel = false;
            int startIndexSelect = -1, finishIndexSelect = -1;
            
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
                if (key.Modifiers == ConsoleModifiers.Control && key.Key == ConsoleKey.C&&sel)
                {
                    classTextEditor.Copy( startIndexSelect, finishIndexSelect);
                    sel = false;
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
                    ChaingeSelect(ref sel, ref startIndexSelect, ref finishIndexSelect, false);
                else if (key.Modifiers == ConsoleModifiers.Shift && key.Key == ConsoleKey.RightArrow)
                    ChaingeSelect(ref sel, ref startIndexSelect, ref finishIndexSelect, true);

                //cancel selected
                if (key.Key == ConsoleKey.Insert) sel = false;

                if (sel)
                {
                    SelectText(startIndexSelect,finishIndexSelect);
                    continue;
                }

                //press button left or Rigth
                if (key.Key == ConsoleKey.LeftArrow)
                {
                    classTextEditor.CurrentNotation = new Notation(classTextEditor.CurrentNotation.Text, classTextEditor.CurrentNotation.PositionCursor - 1);
                    Console.SetCursorPosition(classTextEditor.CurrentNotation.PositionCursor, 1);
                    continue;
                }
                else if (key.Key == ConsoleKey.RightArrow)
                {
                    classTextEditor.CurrentNotation = new Notation(classTextEditor.CurrentNotation.Text, classTextEditor.CurrentNotation.PositionCursor + 1);
                    Console.SetCursorPosition(classTextEditor.CurrentNotation.PositionCursor, 1);
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
            Console.Write(classTextEditor.CurrentNotation.Text);
            Console.SetCursorPosition(classTextEditor.CurrentNotation.PositionCursor, 1);
            }

            private static void SelectText(int startIndex,int finishIndex)
            {
                if (startIndex > finishIndex)
                {
                    int temp = finishIndex;
                    finishIndex = startIndex;
                    startIndex = temp;
                }
                Console.SetCursorPosition(0, 1);
                int index = 0;
                foreach (var ch in classTextEditor.CurrentNotation.Text)
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
            Console.SetCursorPosition(classTextEditor.CurrentNotation.PositionCursor, 1);
        }

            //проверка, что позция выделение находиться на тексте и исправление ее 
            static void CheckAndCorretPosition(ref int oldPositionCursor, int newPositionCursor)
            {
                if (oldPositionCursor < 0) newPositionCursor = 0;
                else if (oldPositionCursor > classTextEditor.CurrentNotation.Text.Length) newPositionCursor = classTextEditor.CurrentNotation.Text.Length - 1;
                else if (oldPositionCursor >= 0 && oldPositionCursor < classTextEditor.CurrentNotation.Text.Length) newPositionCursor = oldPositionCursor;
            }

            /// <summary>
            /// Изменяет позчиции начала и конца выделенного текста
            /// </summary>
            /// <param name="select">было ли выделения</param>
            /// <param name="startIndexSelect">позиция с которого начинается выделение</param>
            /// <param name="finishIndexSelect">позиция с которого заканчивается выделение</param>
            /// <param name="plus">направление вправо</param>
            static void ChaingeSelect(ref bool select, ref int startIndexSelect, ref int finishIndexSelect, bool plus)
            {
                if (select == false)
                {
                    select = true;
                    CheckAndCorretPosition(ref startIndexSelect, classTextEditor.CurrentNotation.PositionCursor);
                    if (plus) CheckAndCorretPosition(ref finishIndexSelect, classTextEditor.CurrentNotation.PositionCursor + 1);
                    else CheckAndCorretPosition(ref finishIndexSelect, classTextEditor.CurrentNotation.PositionCursor - 1);
                }
                else
                {
                    if (plus) CheckAndCorretPosition(ref finishIndexSelect, finishIndexSelect + 1);
                    else CheckAndCorretPosition(ref finishIndexSelect, finishIndexSelect - 1);
                }

                if (startIndexSelect == finishIndexSelect) select = false;

            }
    }
}
