using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FirstSample.Models
{

    public class Person
    {
        public Person(string first, string last)
            => (First, Last) = (first, last);

        void Foo()
        {
            var t1 = (n: 42, foo: "abc");
            var t2 = Divide(7, 2);
            (int res, int rem) = Divide(11, 3);  // deconstruction

        }

        public (int Result, int Remainder) Divide(int x, int y)
        {
            int res = x / y;
            int rem = x % y;
            return (res, rem);
        }

        public string First { get; }
        public string Last { get;  }
    }

    public class Book
    {
        public Book()
        {
            Test1 = "abc";
        }

        public string Test1 { get; }

        public string Test2 => this.Title;

        private string _test3;
        public string Test3
        {
            get => _test3;
            set => _test3 = value;
        }

        public int BookId { get; set; }
        public string Title { get; set; }
        public string Publisher { get; set; }

        public virtual List<Chapter> Chapters { get; set; } = new List<Chapter>();

        public override string ToString() => Title;

        //public void Deconstruct(out string title, out string publisher)
        //{
        //    title = Title;
        //    publisher = Publisher;
        //}
    }

    public static class BookExtensions
    {
        //public static void Deconstruct(this Book book, out string title, out string publisher, out string somethingmore)
        //{
        //    title = book.Title;
        //    publisher = book.Publisher;
        //    somethingmore = "abc";
        //}

        public static void Deconstruct(this Book book, out string title, out string publisher, out string somethingmore)
            => (title, publisher, somethingmore) = (book.Title, book.Publisher, "abc");

    }
}
