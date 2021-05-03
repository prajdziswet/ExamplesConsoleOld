using System;
// расширяющие методы Строки
    public static class StringHelper
    {
        public static bool IsNullOrWhiteSpace(this string str)
        {
            return String.IsNullOrWhiteSpace(str);
        }
    }