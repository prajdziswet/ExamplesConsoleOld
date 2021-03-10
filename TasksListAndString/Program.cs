using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TasksListAndString
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> _list = new List<int>(){1,2,5,8,99,45,55,6};

            try
            {
                //Task "List and String"
                //Task1-3
                ListString.Exercise_1(_list);
                ListString.Exercise_2(_list);
                ListString.Exercise_3(_list,99);
                ListString.Exercise_3(_list, 0);

            }
            catch(Exception e)
            { Console.WriteLine(e.Message);}

            //заглушка
            Console.ReadKey();
        }
    }
}
