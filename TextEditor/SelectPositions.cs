using System;
using System.Security.AccessControl;

namespace TextEditor
{
    //the class responsible for the selected positions in the text 
    public static class SelectPositions
    {
        private static int startIndexSelect = 0, finishIndexSelect = 0;

        public static int CurrentLengthText = 0;

        private static bool _select = false;

        public static bool @Select
        {
            get=>_select;
            set=>_select = false;// попытка присвоить скинет значение.
        }


        //Check position
        static int CheckPosition(int value)
        {
            if (value < 0) return 0;
            else if (value > CurrentLengthText) return CurrentLengthText;
            else return value;
        }

        public static void SetSelectPositions(int Currentposition, bool rightButton)
        {
            int startSelect, finishSelect;
            if (!Select)
            {
                startSelect = CheckPosition(Currentposition);
                finishSelect = CheckPosition(Currentposition);
            }
            else
            {
                startSelect = startIndexSelect;
                finishSelect = finishIndexSelect;
            }

            if (rightButton) finishSelect = CheckPosition(finishSelect + 1);
            else finishSelect = CheckPosition(finishSelect - 1);

            if (startSelect == finishSelect) _select = false;
            else if (startIndexSelect != startSelect || finishIndexSelect != finishSelect)
            {
                _select = true;
                startIndexSelect = startSelect;
                finishIndexSelect = finishSelect;
            }
        }

        public static int GetStartIndexSelect()
        {
            if (startIndexSelect == finishIndexSelect) throw new Exception("Не реализована проверка выбраны ли символы");
            else if (startIndexSelect > finishIndexSelect) return finishIndexSelect;
            else return startIndexSelect;
        }

        public static int GetFinishIndexSelect()
        {
            if (startIndexSelect == finishIndexSelect) throw new Exception("Не реализована проверка выбраны ли символы");
            else if (startIndexSelect > finishIndexSelect) return startIndexSelect;
            else return finishIndexSelect;
        }

    }
}