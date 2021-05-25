using System;
using ClassLibrary;

public static class StringHelper
{
    public static bool IsNullOrWhiteSpace(this string str)
    {
        return String.IsNullOrWhiteSpace(str);
    }

    public static bool IsExist(this string str)
    {
        return !String.IsNullOrWhiteSpace(str);
    }

}