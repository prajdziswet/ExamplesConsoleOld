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
        public static void Exercise_15()
        {
            List<int> x=new List<int>(){ 1,2,3,4};
            int n='5'.CharToInt();
            ListString.ShowMessageList(MultiplcationForEX15(x,n), $"15 Список из числа {number.ToString()} - ");
        }
        //---------
        // I am implementing long multiplication - в столбик
         private static List<int> MultiplcationForEX15(List<int> list, int number)
        {
            var list<int> templist=new List<int>();
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
            templist.Reverse();
            return templist;
        }
        
        

    }
}
