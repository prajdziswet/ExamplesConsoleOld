using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TasksListAndString.FolderClass
{
    public static class Helper
    {
      public static int CharToInt(this Char x)=>Convert.ToInt16(x- '0');
    }
    class Linq
    {
        //4 Write a function that returns the elements on odd positions in a list.
        public static void Exercise_4(List<int> list)
        {
            var temp = list.Where((n, index) => (index+1) % 2 != 0).ToList();
            ListString.ShowMessageList(temp, "4 Только четные позиции: ");
    }

       //8 Write a function on_all that applies a function to every element of a list. Use it to print the first twenty perfect squares. The perfect squares can be found by multiplying each natural number with itself. The first few perfect squares are 1*1= 1, 2*2=4, 3*3=9, 4*4=16. Twelve for example is not a perfect square because there is no natural number m so that m*m=12. (This question is tricky if your programming language makes it difficult to pass functions as arguments.)
        private static bool IsNatural(int n)
        {
            if (n != 1)
            {
                for (int i = 2; i < n; i++)
                 if (n % i == 0) return false;

                return true;
            }
            else return true;
        }

        public static void Exercise_8(List<int> list)
        {
            var temp=list.Where(x=>IsNatural(x)).Select(x=>x*x).ToList();
            ListString.ShowMessageList(temp, "8 Простые квадраты - ");
        }

        //14 Write a function that takes a number and returns a list of its digits. So for 2342 it should return [2,3,4,2].
        public static void Exercise_14(double number)
        {
            List<int> list=number.ToString().ToArray().Select(x=>Convert.ToInt32(x- '0')).ToList();
            ListString.ShowMessageList(list, $"14 Список из числа {number.ToString()} - ");
        }

        //15 Write functions that add, subtract, and multiply two numbers in their digit-list representation (and return a new digit list). If you’re ambitious you can implement Karatsuba multiplication. Try different bases. What is the best base if you care about speed? If you couldn’t completely solve the prime number exercise above due to the lack of large numbers in your language, you can now use your own library for this task.
        // I am implementing long multiplication - в столбик
        public static void Exercise_15<T1,T2>(T1 number1,T2 number2)
        {
            List<int> list1, list2, templist=new List<int>();
            list1=number1.ToString().ToArray().Select(x=>Convert.ToInt32(x- '0')).ToList();
            list2=number2.ToString().ToArray().Select(x=>Convert.ToInt32(x- '0')).ToList();
            //list1.Reverse();
            list2.Reverse();
            int fist=0;
            foreach (int element in list2)
                if (fist==0) {templist=MultiplcationForEX15(list1,element);fist++;}
                else 
                    {
                    var z=MultiplcationForEX15(list1,element);
                    templist=AddListForEx15(templist,z,fist++);
                    }

            ListString.ShowMessageList(templist, $"15 Умножение списком {number1.ToString()}*{number2.ToString()}= ",".","");
        }
        //---------
         private static List<int> MultiplcationForEX15(List<int> list, int number)
        {
            list.Reverse();
            List<int> templist=new List<int>();
            int tempNumber=0;
            foreach (int n in list)
            {
                String strtemp=(n*number+tempNumber).ToString();
                if (strtemp.Length==1)
                {
                    tempNumber=0;
                    templist.Add(strtemp[0].CharToInt());
                }
                else
                {
                    tempNumber=strtemp[0].CharToInt();
                    templist.Add(strtemp[1].CharToInt());
                }
            }
            if (tempNumber!=0) templist.Add(tempNumber);
            list.Reverse();
            templist.Reverse();
                return templist;
        }
        
        private static List<int> AddListForEx15 (List<int> list1, List<int> list2, int shift)
        {
            list1.Reverse();
            list2.Reverse();
            List<int> tempList=new List<int>();
            int tempNumber=0,index=0,indexlist2=0;

            foreach(int element in list1)
            {
                if (index<shift) tempList.Add(element);
                else if (indexlist2<list2.Count)
                    if (tempNumber+element+list2[indexlist2]<=9)
                    {
                        tempList.Add(tempNumber+element+list2[indexlist2++]);
                        tempNumber=0;
                    }
                    else
                    {
                        String str=(tempNumber+element+list2[indexlist2++]).ToString();
                        tempList.Add(str[1].CharToInt());
                        tempNumber=str[0].CharToInt();
                    }
                else if (tempNumber+element<=9)
                    {
                        tempList.Add(tempNumber+element);
                        tempNumber=0;
                    }
                    else
                    {
                        String str=(tempNumber+element).ToString();
                        tempList.Add(str[1].CharToInt());
                        tempNumber=str[0].CharToInt();
                    }
                index++;

            } 
            //если вышли за предел
                if (indexlist2<list2.Count)
                    for(int i=indexlist2;i<list2.Count;i++)
                     if (tempNumber+list2[i]<=9)
                         {
                        tempList.Add(tempNumber+list2[i]);
                        tempNumber=0;
                         }
                     else
                        {
                        String str=(tempNumber+list2[i]).ToString();
                        tempList.Add(str[1].CharToInt());
                            tempNumber=str[0].CharToInt();
                        }
                if (tempNumber!=0) tempList.Add(tempNumber);
                tempList.Reverse();
            return tempList;           
        }
        
        
        

    }
}
