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

        #region Exercises 1-13
        //1 Write a function that returns the largest element in a list.
        public static void Exercise_1(List<int> temp)
        {
            if (temp.Count == 0) throw new Exception("the list is zero-length");
            else ShowMessage(temp.Max(), "1 Наибольшее число списка: ");
        }

        //2 Write function that reverses a list, preferably in place.
        public static void Exercise_2(List<int> temp)
        {
            if (temp.Count == 0) throw new Exception("the list is zero-length");
            else
            {
                temp.Reverse();
                ShowMessageList(temp, "2 Реверсивный список: ");
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
                else ShowMessage(itemcontains, "4 Элемент - ", " не содержиться в списке.");
            }
        }

        //5 Write a function that computes the running total of a list.
        public static void Exercise_5(List<int> list)
        {
            int Sum = 0;
            foreach (var temp in list)
                Sum += temp;
            ShowMessage(Sum, "5 Общая сумма - ");
        }

        //6 Write a function that tests whether a string is a palindrome.
        public static void Exercise_6(String str)
        {
            var str1 = new string(str.Reverse().ToArray()).ToLower();
            if (str1== str.ToLower()) ShowMessage(str, "Cлово/строка полиндром - ");
            else ShowMessage(str, "6 Cлово/строка не полиндром - ");
        }

        //7 Write three functions that compute the sum of the numbers in a list: using a for-loop, a while-loop and recursion. (Subject to availability of these constructs in your language of choice.)
         public static void Exercise_7_1(List<int> list)
        {
            int Sum = 0;
            for (int i=0;i<list.Count;i++)
                Sum += list[i];
            ShowMessage(Sum, "7.1 Общая сумма циклом for- ");
        }

        public static void Exercise_7_2(List<int> list)
        {
            int Sum = 0, i=0;
            while (i<list.Count)
            { Sum += list[i++];}
                
            ShowMessage(Sum, "7.2 Общая сумма циклом while- ");
        }

        public static void Exercise_7_3(List<int> list, int Sum=0, int index=0)
        {
            if (index<list.Count) Exercise_7_3(list,Sum+list[index],++index);
            else ShowMessage(Sum, "7.3 Общая сумма рекурсией- ");
        }

        //9 Write a function that concatenates two lists. [a,b,c], [1,2,3] → [a,b,c,1,2,3]
        public static void Exercise_9(List<int> list1, List<int> list2)
        {
            ShowMessageList(list1.Union(list2).ToList(), "9 Общая сумма рекурсией- ");
        }

       //10 Write a function that combines two lists by alternatingly taking elements, e.g. [a,b,c], [1,2,3] → [a,1,b,2,c,3]
        public static void Exercise_10(List<int> list1, List<int> list2)
        {
            List<int> temp=new List<int>();
            int index=0;
            if (list1.Count>=1)
            {
                foreach (var element in list1)
                { 
                    temp.Add(element);
                    if (index<list2.Count) temp.Add(list2[index++]);
                }

                if (index<list2.Count) for (int i=index;i<list2.Count;i++) temp.Add(list2[index++]);
             }
            else temp.AddRange(list2);
            ShowMessageList(temp, "10 Общий список- ");
        }

        //11 Write a function that merges two sorted lists into a new sorted list. [1,4,6],[2,3,5] → [1,2,3,4,5,6]. You can do this quicker than concatenating them followed by a sort
                public static void Exercise_11(List<int> list1, List<int> list2)
            {
             var temp=list1.Union(list2).ToList();
            temp.Sort();
             ShowMessageList(temp, "11 Общий отсортированный список - ");
            }

        //12 Write a function that rotates a list by k elements. For example [1,2,3,4,5,6] rotated by two becomes [3,4,5,6,1,2]. Try solving this without creating a copy of the list. How many swap or move operations do you need?
            public static void Exercise_12(List<int> list1, int k)
            {
             int i=k;
            if (k<=list1.Count)
                while (i>0)
                {
                    int temp_int = list1[0];
                    list1.RemoveAt(0);
                    list1.Add(temp_int);
                    i--;
                }
             ShowMessageList(list1, "12 Cписок - ");
            }
        //13 Write a function that computes the list of the first 100 Fibonacci numbers. The first two Fibonacci numbers are 1 and 1. The n+1-st Fibonacci number can be computed by adding the n-th and the n-1-th Fibonacci number. The first few are therefore 1, 1, 1+1=2, 1+2=3, 2+3=5, 3+5=8.
        public static void Exercise_13()
        {
            List<double> list=new List<double>(){1,1};
            for (int i=1;i<=98;i++) list.Add(list[i]+list[i-1]);
            ShowMessageList(list, "13 Список Фибоначи: ");
        }
        #endregion

        #region Exercise 17 Sort - 18
        //17 Implement the following sorting algorithms: Selection sort, Insertion sort, Merge sort, Quick sort, Stooge Sort.Check Wikipedia for descriptions.
        // Selection sort
        public static void Exercise_17_1(List<int> list)
        {
            for (int i = 0; i < list.Count - 1; i++)
            {
                int min = i;
                for (int j = i + 1; j < list.Count; j++)
                {
                    if (list[j] < list[min])
                    {
                        min = j;
                    }
                }
                int dummy = list[i];
                list[i] = list[min];
                list[min] = dummy;
            }

            ShowMessageList(list, "Сортированный-выборкой массив: ");
        }

        // Insertion sort
        public static void Exercise_17_2(List<int> list)
        {
            int i = 0,i1=1;

            while (i1<list.Count)
            {
                if (list[i1-1] >list[i1])
                {
                    int temp = list[i1];
                    for (int j = i1-1; j >=0; j--)
                    {
                        if (list[j] >temp)
                        {
                            i = j; 
                            list[j + 1] = list[j];

                        }
                        else break;
                    }

                   list[i] = temp;
                }

                i1++;
            }

            ShowMessageList(list, "Сортированный-вставкой массив: ");
        }

        //qiuq sort
        private static void sorting(List<int> arr, int first, int last)
        {
            int p = arr[(last - first) / 2 + first];
            int temp;
            int i = first, j = last;
            while (i <= j)
            {
                while (arr[i] < p && i <= last) ++i;
                while (arr[j] > p && j >= first) --j;
                if (i <= j)
                {
                    temp = arr[i];
                    arr[i] = arr[j];
                    arr[j] = temp;
                    ++i; --j;
                }
            }
            if (j > first) sorting(arr, first, j);
            if (i < last) sorting(arr, i, last);
        }

        //quit sort
        public static void Exercise_17_3(List<int> list)
        {
            sorting(list,0,list.Count-1);
            ShowMessageList(list, "Сортированный-быстрой сорт массив: ");
        }

        //сортировка по частям
        static void StoogeSort(int[] array, int startIndex, int endIndex)
        {
            if (array[startIndex] > array[endIndex])
            {
                var t = array[startIndex];
                array[startIndex] = array[endIndex];
                array[endIndex] = t;
            }

            if (endIndex - startIndex > 1)
            {
                var len = (endIndex - startIndex + 1) / 3;
                StoogeSort(array, startIndex, endIndex - len);
                StoogeSort(array, startIndex + len, endIndex);
                StoogeSort(array, startIndex, endIndex - len);
            }

        }

        //Stooge Sort
        public static void Exercise_17_4(List<int> list)
        {
            sorting(list, 0, list.Count - 1);
            ShowMessageList(list, "Сортированный-по частям массив: ");
        }

        //18 Implement binary search
        //метод для рекурсивного бинарного поиска
        static int BinarySearch(List<int> list, int searchedValue, int first, int last)
        {
            //границы сошлись
            if (first > last)
            {
                //элемент не найден
                return -1;
            }

            //средний индекс подмассива
            var middle = (first + last) / 2;
            //значение в средине подмассива
            var middleValue = list[middle];

            if (middleValue == searchedValue)
            {
                return middle;
            }
            else
            {
                if (middleValue > searchedValue)
                {
                    //рекурсивный вызов поиска для левого подмассива
                    return BinarySearch(list, searchedValue, first, middle - 1);
                }
                else
                {
                    //рекурсивный вызов поиска для правого подмассива
                    return BinarySearch(list, searchedValue, middle + 1, last);
                }
            }
        }

        public static void Exercise_18(List<int> list,int SeachNumber)
        {
            sorting(list, 0, list.Count - 1);
            var temp = BinarySearch(list, SeachNumber, 0, list.Count - 1);
            if (temp==-1) Console.WriteLine($"Item {SeachNumber} not find..");
            else ShowMessage(temp, $"Item {SeachNumber} in position: ");
        }

        #endregion


    }
}