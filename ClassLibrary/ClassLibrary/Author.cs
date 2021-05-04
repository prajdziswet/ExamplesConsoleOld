using System;

namespace ClassLibrary
{
    public class Author
    {
        public int ID;
        public String Name;
        public String LastName;
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