using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TasksListAndString.FolderClass;

namespace TasksListAndString
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> _list = new List<int>(){1,2,5,8,99,45,55,6};
            List<int> _list2 = new List<int>(){10,11};
            
            try
            {
                ListString.ShowMessageList(_list, "Исходный список: ");
                //Task1-13
                ListString.Exercise_1(_list);
                ListString.Exercise_2(_list);
                ListString.Exercise_3(_list,99);
                ListString.Exercise_3(_list, 0);
                Linq.Exercise_4(_list);
                ListString.Exercise_5(_list);
                ListString.Exercise_6("Дом мод");
                ListString.Exercise_6("Светило солнце");
                ListString.Exercise_7_1(_list);
                ListString.Exercise_7_2(_list);
                ListString.Exercise_7_3(_list);
                Linq.Exercise_8(_list);
                ListString.Exercise_9(_list,_list2);
                ListString.Exercise_10(_list,_list2);
                ListString.Exercise_11(_list,_list2);
                ListString.Exercise_12(_list,3);
                ListString.Exercise_13();
                Console.Write("-----------Сделано 13 задач-----------\n\n");
                 //Task14-..
                ListString.ShowMessageList(_list, "Исходный список: ");
                Linq.Exercise_14(3456);
                Linq.Exercise_15("1234",1234);
            }
            catch(Exception e)
            { Console.WriteLine(e.Message);}

            //заглушка
            Console.ReadKey();
        }
    }
}
