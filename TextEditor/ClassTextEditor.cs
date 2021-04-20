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
                    //устанавливаем длину текста
                    SelectPositions.CurrentLengthText = value.Text.Length;
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

        //COPY {index} - copies a substring of output starting from {index} and to the end (does nothing if {index} is out of range)
        public void Copy()
        {
            if (SelectPositions.Select)
            {
                String newText = CurrentNotation.Text.Substring(SelectPositions.GetFistIndexSelect(), SelectPositions.GetLastIndexSelect() - SelectPositions.GetFistIndexSelect());
                Clipboard.Clear();
                Clipboard.SetText(newText);
                SelectPositions.CancelSelect();//сбрасываем выделение
            }
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