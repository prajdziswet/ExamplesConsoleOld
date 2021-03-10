using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TasksListAndString.FolderClass
{
    class Linq
    {
        //4 Write a function that returns the elements on odd positions in a list.
        public static void Exercise_4(List<int> list)
        {
            var temp = list.Where((n, index) => (index+1) % 2 != 0).ToList();
            ListString.ShowMessageList(temp, "Только четные позиции: ");
    }

    }
}
