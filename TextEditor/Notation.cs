namespace TextEditor
{
    //Одиночная запись, с позицией курсора - для возвращение в нужную позицию
    public class Notation
    {
        internal string Text;

        private int _positionCursor;
        internal int PositionCursor
        {
            get => _positionCursor;
            set
            {
                _positionCursor = CorrectPositionCursor(value);
            }
        }

        //checks that the cursor is in the text and return Correct position
        public int CorrectPositionCursor(int value)
        {
            if (value < 0) return 0;
            else if (value > Text.Length) return Text.Length;
            else return value;
        }

        /// <summary>
        /// Create class Notation
        /// </summary>
        /// <param name="text">Text</param>
        /// <param name="positionCursor">current position cursor</param>
        public Notation(string text, int positionCursor)
        {
            Text = text;
            PositionCursor = positionCursor;
        }

        public bool Equals(Notation n1)
        {
            return this.Text == n1.Text && 
                   this.PositionCursor == n1.PositionCursor;
        }

    }

}