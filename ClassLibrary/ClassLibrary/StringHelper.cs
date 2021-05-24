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

    public static String ToString(this Author author)
    {
        return $"{author.LastName} {author.Name}";
    }
    public static String ToString(this Book book)
    {
        return $"Book \"{book.ISBN}\" - \"{book.NameBook}\" - \"{book.AuthorBook.ToString()}\" ";
    }
}