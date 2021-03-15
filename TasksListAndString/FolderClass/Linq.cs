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
            ListString.ShowMessageList(temp, "Простые квадраты - ");
        }

    }
}
