using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace TasksListAndString
{
    public static class ListString
    {
        #region function view
        // Show message concole
        public static void ShowMessage<T>(T value, String first = "", String end = ".")
        {
            Console.WriteLine(first+value.ToString()+end);
        }
        public static void ShowMessageList<T>(List<T> value,String First="", String end = ".", String split = "|")
        {
            Console.Write(First);
            foreach (var temp in value)
            {
                Console.Write(temp + split);
            }
            Console.Write(end+"\n");
        }
        #endregion

        //1 Write a function that returns the largest element in a list.
        public static void Exercise_1(List<int> temp)
        {
            if (temp.Count == 0) throw new Exception("the list is zero-length");
            else ShowMessage(temp.Max(), "Наибольшее число списка: ");
        }

        //2 Write function that reverses a list, preferably in place.
        public static void Exercise_2(List<int> temp)
        {
            if (temp.Count == 0) throw new Exception("the list is zero-length");
            else
            {
                temp.Reverse();
                ShowMessageList(temp, "Реверсивный список: ");
                temp.Reverse();
            }
        }

        //3 Write a function that checks whether an element occurs in a list.
        public static void Exercise_3(List<int> temp, int itemcontains)
        {
            if (temp.Count == 0) throw new Exception("the list is zero-length");
            else
            {
                if (temp.Contains(itemcontains)) ShowMessage(itemcontains, "Элемент - ","содержиться в списке.");
                else ShowMessage(itemcontains, "Элемент - ", " не содержиться в списке.");
            }
        }

        //5 Write a function that computes the running total of a list.
        public static void Exercise_5(List<int> list)
        {
            int Sum = 0;
            foreach (var temp in list)
                Sum += temp;
            ShowMessage(Sum, "Общая сумма - ");
        }

        //6 Write a function that tests whether a string is a palindrome.
        public static void Exercise_6(String str)
        {
            var str1 = new string(str.Reverse().ToArray()).ToLower();
            if (str1== str.ToLower()) ShowMessage(str, "Cлово/строка полиндром - ");
            else ShowMessage(str, "Cлово/строка не полиндром - ");
        }

        //7 Write three functions that compute the sum of the numbers in a list: using a for-loop, a while-loop and recursion. (Subject to availability of these constructs in your language of choice.)
         public static void Exercise_7_1(List<int> list)
        {
            int Sum = 0;
            for (int i=0;i<list.Count;i++)
                Sum += list[i];
            ShowMessage(Sum, "Общая сумма циклом for- ");
        }

        public static void Exercise_7_2(List<int> list)
        {
            int Sum = 0, i=0;
            while (i<list.Count)
            { Sum += list[i++];}
                
            ShowMessage(Sum, "Общая сумма циклом while- ");
        }

        public static void Exercise_7_3(ref List<int> list, int Sum=0, int index=0)
        {
            if (index<list.Count) Exercise_7_3(ref list,Sum+list[index],++index);
            else ShowMessage(Sum, "Общая сумма рекурсией- ");
        }


}
}