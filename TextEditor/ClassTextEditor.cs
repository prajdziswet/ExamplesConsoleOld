    using System;
    using System.Collections.Generic;
    using System.Runtime.Remoting.Messaging;
    using System.Threading;
    using System.Windows;
 

    namespace TextEditor
    {
        public class Text
        {
            public string str;
            public int position;

            public Text(string str, int position)
            {
                this.str = str;
                this.position = position;
            }
        }

        public class ClassTextEditor
    {
        #region value and internal function
        public ClassTextEditor()
            {
            }

            private List<Text> _fields=new List<Text>(){ new Text("", 0) };
            private int _currentField = 0;
            private int CurrentField
            {
                get => _currentField;
                set
                {
                    if (_fields == null || _fields.Count != 0 && value > 0 && value < _fields.Count)
                        _currentField = value;
                }

            }
            private int _currentPosition = 0;
            public int CurrentPosition
            {
                get => _currentPosition;
                set
                {
                    if (_fields == null || _fields.Count != 0 && value >= 0 && value <= Fields.str.Length)
                        _currentPosition = value;
                }

            }

            public Text Fields
            {
                get=>_fields[_currentField];

                set
                {
                    if (value != null)
                    {
                        _fields.Add(value);
                        CurrentField++;
                }
                }
            }


            //INSERT {text} - appends {text} to output;
            public void Insert(string text)
            {
                Text t1 = new Text("", 0);
                t1.str = Fields.str.Insert(_currentPosition, text);
                t1.position = _currentPosition + text.Length;
                Fields = t1;
                CurrentPosition = t1.position;
            }
            #endregion

        //DELETE - deletes the last symbol from output(does nothing if output is empty);
        public void Delete()
        {
            if (!String.IsNullOrEmpty(Fields.str))
            {
                Text text=new Text("",0);
                if (_currentPosition >= 1) text.str = Fields.str.Remove(_currentPosition - 1,1);
                text.position = _currentPosition - 1;
                Fields = text;
                CurrentPosition--;
            }
        }

        //COPY {index} - copies a substring of output starting from {index} and to the end (does nothing if {index} is out of range)
        //I didn't copy to end
        public void Copy(int startPosition, int finishPosition)
        {
            String newText = Fields.str.Substring(startPosition, finishPosition - startPosition);
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
            if (CurrentField>0)
            {
                CurrentField = CurrentField - 1;
            }
        }
    }

}