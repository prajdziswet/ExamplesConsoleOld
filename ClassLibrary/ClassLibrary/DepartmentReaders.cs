using System;
using System.Collections.Generic;
using System.Linq;

namespace ClassLibrary
{
    public class DepartmentReaders
    {
        private List<Reader> Readers
        {
            get;
            set;
        }
            = new List<Reader>();


        public void AddReader(Reader reader)
        {
            if (reader == null)
            {
                throw new ArgumentNullException("Reader reference is null");
            }
            Reader foundReader =
                Readers.FirstOrDefault(temp=> temp.Name==reader.Name&&temp.LastName==reader.LastName);

            if (foundReader == null)
            {
                Readers.Add(reader);
            }
            else
            {
                throw new ArgumentException("This reader exists in List");
            }
        }

        public Reader GetReader(int IDReader)
        {
            return Readers.FirstOrDefault(x => x.ID == IDReader);
        }
    }
}