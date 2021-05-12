using System;

namespace ClassLibrary
{
    public class Reader
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

        public Reader(String Name, String LastName)
        {
            //maybe better check here or all the same Library??
            if (Name.IsNullOrWhiteSpace())
            {
                throw new ArgumentNullException("Name is empty");
            }
            else if (LastName.IsNullOrWhiteSpace())
            {
                throw new ArgumentNullException("Name is empty");
            }

            ID=++Count;
            this.Name = Name;
            this.LastName = LastName;
        }
    }
}
