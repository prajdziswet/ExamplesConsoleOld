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
                if (0 <= value && value <= Text.Length) _positionCursor = value;
                else if (value<0) _positionCursor = 0;
                else if (value > Text.Length) _positionCursor = Text.Length;
            }
        }
        
        /// <summary>
        /// Create struct Natation
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