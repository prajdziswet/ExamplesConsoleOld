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
                //Task1
                Console.WriteLine("Наибольшее число списка: "+ListString.Task_1(_list));
                //Task2
                _list.Reverse();
                foreach (var temp in _list)
                {
                    Console.Write(temp + "|");
                }

            }
            catch(Exception e)
            { Console.WriteLine(e.Message);}

            //заглушка
            Console.ReadKey();
        }
    }
}
