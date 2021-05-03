using System;

namespace ClassLibrary
{
    public class Author
    {
        public int ID;
        public String Name;
        public String LastName;

        public Author(String name, String lastName, int countAuthors)
        {
            ID = ++countAuthors;
            Name = name;
            LastName = lastName;
        }
    }
}