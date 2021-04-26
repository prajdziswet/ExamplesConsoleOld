using System;
using System.Security.AccessControl;

namespace TextEditor
{
    //the class responsible for the selected positions in the text 
    public class SelectPositions
    {
        internal int StartIndexSelect
        {
            get;
            set;
        }

        internal int FinishIndexSelect
        {
            get;
            set;
        }

        private bool _select;
        public bool @Select
        {
            get
            {
                if (StartIndexSelect == FinishIndexSelect) _select = false;
                return _select;
            }
            set => _select = value;
        }

        public int GetFistIndexSelect()
        {
            if (StartIndexSelect == FinishIndexSelect) throw new Exception("Не реализована проверка выбраны ли символы");
            else if (StartIndexSelect > FinishIndexSelect) return FinishIndexSelect;
            else return StartIndexSelect;
        }

        public int GetLastIndexSelect()
        {
            if (StartIndexSelect == FinishIndexSelect) throw new Exception("Не реализована проверка выбраны ли символы");
            else if (StartIndexSelect > FinishIndexSelect) return StartIndexSelect;
            else return FinishIndexSelect;
        }

    }
}