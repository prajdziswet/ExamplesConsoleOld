using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace TasksListAndString
{
    public static class ListString
    {
        //return Max in list
        public static int Task_1(List<int> temp)
        {
            if (temp.Count == 0) throw new Exception("the list is zero-length");
            return temp.Max();
        }
    }
}