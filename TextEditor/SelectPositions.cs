using System;
using System.Security.AccessControl;

namespace TextEditor
{
    //the class responsible for the selected positions in the text 
    public class SelectPositions
    {
        private int startIndexSelect = 0, finishIndexSelect = 0;

        private int StartIndexSelect
        {
            get => startIndexSelect;
            set => startIndexSelect = CorrectPositionCursor(value);
        }

        private int FinishIndexSelect
        {
            get => finishIndexSelect;
            set => finishIndexSelect = CorrectPositionCursor(value);
        }

        internal int CurrentLengthText = 0;

        private bool _select = false;

        public bool @Select
        {
            get =>_select;
        }

        public void CancelSelect()
        {
            startIndexSelect = 0; 
            finishIndexSelect = 0;
            _select = false;
        }


        //checks that the cursor is in the text and return Correct position
        int CorrectPositionCursor(int value)
        {
            if (value < 0) return 0;
            else if (value > CurrentLengthText) return CurrentLengthText;
            else return value;
        }

        public void SetSelectPositions(int currentPosition, bool rightButton)
        {
            if (!Select)
            {
                StartIndexSelect = currentPosition;
                FinishIndexSelect = currentPosition;
                _select = true;
            }


            if (rightButton) FinishIndexSelect = FinishIndexSelect + 1;
            else FinishIndexSelect = FinishIndexSelect - 1;

            if (StartIndexSelect == FinishIndexSelect) CancelSelect();

        }

        public int GetFistIndexSelect()
        {
            if (startIndexSelect == finishIndexSelect) throw new Exception("Не реализована проверка выбраны ли символы");
            else if (startIndexSelect > finishIndexSelect) return finishIndexSelect;
            else return startIndexSelect;
        }

        public int GetLastIndexSelect()
        {
            if (startIndexSelect == finishIndexSelect) throw new Exception("Не реализована проверка выбраны ли символы");
            else if (startIndexSelect > finishIndexSelect) return startIndexSelect;
            else return finishIndexSelect;
        }

    }
}