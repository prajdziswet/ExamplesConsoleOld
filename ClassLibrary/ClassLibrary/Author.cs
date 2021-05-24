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

        public bool Equals(Author author) 
            {
            if (author is null)
            {
                return false;
            }

            // Optimization for a common success case.
            if (Object.ReferenceEquals(this, author))
            {
                return true;
            }

            // If run-time types are not exactly the same, return false.
            if (this.GetType() != author.GetType())
            {
                return false;
            }

            return Name == author.Name && LastName == author.LastName;
            }

        public static bool operator ==(Author lhs, Author rhs)
        {
            if (lhs is null)
            {
                if (rhs is null)
                {
                    return true;
                }

                // Only the left side is null.
                return false;
            }
            // Equals handles case of null on right side.
            return lhs.Equals(rhs);
        }

        public static bool operator !=(Author lhs, Author rhs) => !(lhs == rhs);

    }
}