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
            if (name.IsNullOrWhiteSpace() || lastName.IsNullOrWhiteSpace())
            {
                throw new ArgumentNullException("The author's first or last name is empty ");
            }

            ID = ++Count;
            Name = name;
            LastName = lastName;
        }

        public bool EqualArgument(Author author) =>
            Name == author.Name && LastName == author.LastName;
    }
}