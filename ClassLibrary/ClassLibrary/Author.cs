using System;

namespace ClassLibrary
{
    public class Author
    {
        public int ID
        {
            get;
            private set;
        }

        public String Name
        {
            get;
            private set;
        }

        public String LastName
        {
            get;
            private set;
        }
        public static int Count
        {
            get;
            private set;
        }

        public Author(String name, String lastName)
        {
            ID = ++Count;
            Name = name;
            LastName = lastName;
        }
    }
}