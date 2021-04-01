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

            //bool spectrum
            static void boolSpectrum(ref int X,int temp)
            {
                if (temp < 0) X = 0;
                else if (temp > classTextEditor.Fields.str.Length) X = classTextEditor.Fields.str.Length - 1;
                else if (temp >= 0 && temp < classTextEditor.Fields.str.Length) X = temp;
            }

            static void ChaingeSelect(ref bool select, ref int startIndex, ref int finishIndex, bool plus)
            {
            if (select == false)
            {
                select = true;
                boolSpectrum(ref startIndex, classTextEditor.CurrentPosition);
                if (plus) boolSpectrum(ref finishIndex, classTextEditor.CurrentPosition + 1);
                else boolSpectrum(ref finishIndex, classTextEditor.CurrentPosition-1);
            }
            else
            {
                if (plus) boolSpectrum(ref finishIndex, finishIndex+1);
                else boolSpectrum(ref finishIndex, finishIndex - 1);
            }

            if (startIndex == finishIndex) select = false;

            }
        
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
                    if (startIndexSelect > finishIndexSelect) classTextEditor.Copy(finishIndexSelect, startIndexSelect);
                    else classTextEditor.Copy( startIndexSelect, finishIndexSelect);
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
                    classTextEditor.CurrentPosition--;
                    Console.SetCursorPosition(classTextEditor.CurrentPosition, 1);
                    continue;
                }
                else if (key.Key == ConsoleKey.RightArrow)
                {
                    classTextEditor.CurrentPosition++;
                    Console.SetCursorPosition(classTextEditor.CurrentPosition, 1);
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
            Console.Write(classTextEditor.Fields.str);
            Console.SetCursorPosition(classTextEditor.CurrentPosition, 1);
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
                foreach (var ch in classTextEditor.Fields.str)
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
            Console.SetCursorPosition(classTextEditor.CurrentPosition, 1);
        }
    }
}
