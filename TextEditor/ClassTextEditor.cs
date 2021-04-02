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
        public Notation CurrentNotation
        {
            get => _currentNotation;
            set
            {
                    //проверяем что изменился текст а не курсор
                    if (value.Text != _currentNotation.Text)
                    {
                        if (NumberNotation == 0 || NumberNotation<=_listNotations.Count)
                        {
                            _listNotations.Add(_currentNotation);
                            NumberNotation++;
                        }
                        else
                        {
                            _listNotations[NumberNotation - 1] = value;
                            NumberNotation++;
                        }
                        //устанавливаем новое значение
                        _currentNotation = value;
                    }
                    else
                        _currentNotation.PositionCursor = value.PositionCursor;
            }
        }
#endregion

        //INSERT {text} - appends {text} to output;
        public void Insert(string text)
        {
            String newText = CurrentNotation.Text.Insert(CurrentNotation.PositionCursor, text);
            int newPosition = CurrentNotation.PositionCursor + text.Length;
            Notation temp = new Notation(newText, newPosition);

            CurrentNotation = temp;
        }
        

        //DELETE - deletes the last symbol from output(does nothing if output is empty);
        public void Delete()
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

        private bool CheckPosition(ref int startPosition, ref int finishPosition)
        {
            //проверка что копируемые позиции находяться на тексте, может и не надо
            if (startPosition < 0) startPosition = 0;
            else if (startPosition > CurrentNotation.Text.Length) startPosition = CurrentNotation.Text.Length;
            if (finishPosition < 0) finishPosition = 0;
            else if (finishPosition > CurrentNotation.Text.Length) finishPosition = CurrentNotation.Text.Length;
            //проверка что позиции не равны и правильный порядок
            if (startPosition == finishPosition) return false;
            else if (startPosition > finishPosition) //позиции находяться в обратном порядке
            {
                int temp = finishPosition;
                finishPosition = startPosition;
                startPosition = temp;
            }

            return true;
        }

        //COPY {index} - copies a substring of output starting from {index} and to the end (does nothing if {index} is out of range)
        public void Copy(int startPosition, int finishPosition)
        {
            if (!CheckPosition(ref startPosition, ref finishPosition)) return;

            String newText = CurrentNotation.Text.Substring(startPosition, finishPosition - startPosition);
            Clipboard.Clear();
            Clipboard.SetText(newText);
        }


        //PASTE - appends copied text to output (does nothing if nothing has been copied);
        public void Paste()
        {
            if (Clipboard.ContainsText())
            {
                String newText = Clipboard.GetText();
                Insert(newText);
            }
        }
        //UNDO - undoes one last successful operation (INSERT/DELETE/PASTE). can be called multiple times in a row to undo multiple operations.
        public void Undo()
        {
            if (NumberNotation > 0)
            {
                _currentNotation = _listNotations[--NumberNotation];
            }
        }
    }

}