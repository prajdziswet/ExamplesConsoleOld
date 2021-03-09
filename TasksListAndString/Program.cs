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
                Console.WriteLine("Наибольшее число списка: "+ListString.Task_1(_list));
            }
            catch(Exception e)
            { Console.WriteLine(e.Message);}

            //заглушка
            Console.ReadKey();
        }
    }
}
