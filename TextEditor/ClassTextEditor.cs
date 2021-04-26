    using System;
    using System.Collections.Generic;
    using System.Runtime.Remoting.Messaging;
    using System.Threading;
    using System.Windows;
 

    namespace TextEditor
    {
    public class ClassTextEditor
    {
#region value and internal function

        public SelectPositions @SelectPositions =new SelectPositions();
        //Список записей (запись - текст с позицией курсора)
        private List<Notation> _listNotations = new List<Notation>();

        //Номер текущей записи
        private int _numberNotation = 0;
        private int NumberNotation
        {
            get => _numberNotation;
            set
            {
                if (value <= _listNotations.Count)
                    _numberNotation = value;
            }

        }

        //Текущая запись (текст и курсор) с которой работаем
        private Notation _currentNotation = new Notation("", 0);
        private Notation CurrentNotation
        {
            get => _currentNotation;
            set
            {
                    //проверяем что изменился текст а не курсор
                    if (value.Text != _currentNotation.Text)
                    {
                        SaveNotation();
                    //устанавливаем новое значение
                     _currentNotation = new Notation(value.Text, value.PositionCursor);
                    }
            }
        }

        //позиция курсора доступная из самого редактора
        public int PositionCursor
        {
            get => _currentNotation.PositionCursor;
            set => _currentNotation.PositionCursor = value;
        }

        //текст 
        public string Text
        {
            get=>_currentNotation.Text;
        }

        private void SaveNotation()
        {
            if (NumberNotation == 0 || NumberNotation <= _listNotations.Count)
            {
                _listNotations.Add(_currentNotation);
                NumberNotation++;
            }
            else
            {
                _listNotations.RemoveRange(NumberNotation - 1, _listNotations.Count- NumberNotation);
                _listNotations.Add(_currentNotation);
                NumberNotation++;
            }
        }
        #endregion

        //INSERT {text} - appends {text} to output;
        private void Insert(string text)
        {
            String newText = CurrentNotation.Text.Insert(CurrentNotation.PositionCursor, text);
            int newPosition = CurrentNotation.PositionCursor + text.Length;
            Notation temp = new Notation(newText, newPosition);

            CurrentNotation = temp;
        }
        

        //DELETE - deletes the last symbol from output(does nothing if output is empty);
        private void Delete()
        {
            if (!String.IsNullOrEmpty(CurrentNotation.Text))
            {
                if (CurrentNotation.PositionCursor >= 1)
                {
                    String newText = CurrentNotation.Text.Remove(CurrentNotation.PositionCursor - 1, 1);
                    int newPosition = CurrentNotation.PositionCursor - 1;
                    Notation temp = new Notation(newText, newPosition);

                    CurrentNotation = temp;
                }
            }
        }

        //COPY {index} - copies a substring of output starting from {index} and to the end (does nothing if {index} is out of range)
        private void Copy()
        {
            if (SelectPositions.Select)
            {
                String newText = CurrentNotation.Text.Substring(SelectPositions.GetFistIndexSelect(), SelectPositions.GetLastIndexSelect() - SelectPositions.GetFistIndexSelect());
                Clipboard.Clear();
                Clipboard.SetText(newText);
            }
            else
            {
                Clipboard.Clear();
                Clipboard.SetText(CurrentNotation.Text);
            }
        }


        //PASTE - appends copied text to output (does nothing if nothing has been copied);
        private void Paste()
        {
            if (Clipboard.ContainsText())
            {
                String newText = Clipboard.GetText();
                Insert(newText);
            }
        }
        //UNDO - undoes one last successful operation (INSERT/DELETE/PASTE). can be called multiple times in a row to undo multiple operations.
        private void Undo()
        {
            if (NumberNotation > 0)
            {
                _currentNotation = _listNotations[--NumberNotation];
            }
        }

        private void SetSelectPositions(bool rightButton=true)
        {
            if (!SelectPositions.Select)
            {
                SelectPositions.StartIndexSelect = CurrentNotation.PositionCursor;
                SelectPositions.FinishIndexSelect = CurrentNotation.PositionCursor;
                SelectPositions.Select = true;
            }

            if (rightButton) SelectPositions.FinishIndexSelect = CurrentNotation.CorrectPositionCursor(SelectPositions.FinishIndexSelect + 1);
            else SelectPositions.FinishIndexSelect = CurrentNotation.CorrectPositionCursor(SelectPositions.FinishIndexSelect - 1);
        }

        //Main method, which Analisation and runs action
        public bool Main(ConsoleKeyInfo key)
        {
            if (key.Key == ConsoleKey.Escape)
            {
                return false;
            }

            //вставка ctrl+c
            if (key.Modifiers == ConsoleModifiers.Control && key.Key == ConsoleKey.C)
            {
                Copy();
                return true;
            }

            //вставка ctrl+V
            if (key.Modifiers == ConsoleModifiers.Control && key.Key == ConsoleKey.V)
            {
                Paste();
                return true;
            }

            //press ctrl+z
            if (key.Modifiers == ConsoleModifiers.Control && key.Key == ConsoleKey.Z)
            {
                Undo();
                return true;
            }

            //press shift+left(+rigth)
            if (key.Modifiers == ConsoleModifiers.Shift && key.Key == ConsoleKey.LeftArrow)
            {
                SetSelectPositions(false);
                return true;
            }
            else if (key.Modifiers == ConsoleModifiers.Shift && key.Key == ConsoleKey.RightArrow)
            {
                SetSelectPositions(true);
                return true;
            }

            SelectPositions.Select = false;

            //press button left or Rigth
            if (key.Key == ConsoleKey.LeftArrow)
            {
                PositionCursor--;
                return true;
            }
            else if (key.Key == ConsoleKey.RightArrow)
            {
                PositionCursor++;
                return true;
            }

            //press backspace or del
            if (key.Key == ConsoleKey.Backspace | key.Key == ConsoleKey.Delete)
            {
                Delete();
                return true;
            }

            if (key.KeyChar == '\u0000') return true;
            else
            {
                Insert(key.KeyChar.ToString());
                return true;
            }
        }
    }

}