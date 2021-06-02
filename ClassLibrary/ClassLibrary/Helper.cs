using System;
using ClassLibrary;
using System.Collections.Generic;
using System.Linq;

public static class Helper
{
    public static bool IsNullOrWhiteSpace(this string str)
    {
        return String.IsNullOrWhiteSpace(str);
    }

    public static bool IsExist(this string str)
    {
        return !String.IsNullOrWhiteSpace(str);
    }

    public static List<Book> FreeBook(this List<Book> AllBook, List<BorrowedBook> BorrowedBooks)
    {
        return AllBook.Where(book => !BorrowedBooks.Any(borrowedBook => borrowedBook.ID == book.ID)).ToList();
    }

}