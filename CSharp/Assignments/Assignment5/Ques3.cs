using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment5
{
    public class Book
    {
        public string BookName;
        public string AuthorName;

        public Book(string bookname,string authorname)
        {
            BookName = bookname;
            AuthorName = authorname;
        }
        public void display()
        {
            Console.WriteLine($"Book Name: {BookName} \t Author Name: {AuthorName}");
        }
    }
    public class BookShelf
    {
        private Book[] books=new Book[5];
        public Book this[int index]
        {
            get { return books[index];}
            set { books[index] = value;}

        }
        public void DisplayAll()
        {
            for(int i = 0; i < 5; i++)
            {
                books[i].display();
            }
        }
    }
    internal class Ques3
    {
       public static void Bookindex()
        {
            BookShelf shelf = new BookShelf();
            shelf[0] = new Book("Holy", "Abc");
            shelf[1] = new Book("Mercy", "efg");
            shelf[2] = new Book("Sunshine", "hij");
            shelf[3] = new Book("World wars", "klm");
            shelf[4] = new Book("7 wonders", "nop");

            shelf.DisplayAll();
        }
    }
}
