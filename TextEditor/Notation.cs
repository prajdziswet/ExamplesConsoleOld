namespace TextEditor
{
    //Одиночная запись, с позицией курсора - для возвращение в нужную позицию
    internal class Notation
    {
        internal string Text;

        private int _positionCursor;
        internal int PositionCursor
        {
            get => _positionCursor;
            set
            {
                if (0 <= value && value <= Text.Length) _positionCursor = value;
            }
        }
        
        /// <summary>
        /// Create struct Natation
        /// </summary>
        /// <param name="text">Text</param>
        /// <param name="positionCursor">current position cursor</param>
        internal Notation(string text, int positionCursor)
        {
            Text = text;
            PositionCursor = positionCursor;
        }

    }

}