using System;
using System.Collections.Generic;

namespace ClassLibrary
{
    public class CardReader
    {
        public int ID;
        public Reader Reader;
        public IEnumerable<Book> Books;
    }
}