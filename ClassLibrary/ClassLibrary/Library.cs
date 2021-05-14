using System;
using System.Collections.Generic;
using System.Linq;

namespace ClassLibrary
{
    public class Library
    {



        public List<Reader> Readers
        {
            get;
            private set;
        }
            = new List<Reader>();


        public void AddReader(Reader reader)
        {
            if (reader == null)
            {
                throw new ArgumentNullException("Reader reference is null");
            }
            Reader returnReader =
                Readers.FirstOrDefault(card => card.ID==reader.ID);

            if (returnReader == null)
            {
                Readers.Add(reader);
            }
            else
            {
                throw new ArgumentException("This reader exists in List");
            }
        }


    }
}
