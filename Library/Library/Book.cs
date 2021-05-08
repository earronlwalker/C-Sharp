using System;
using System.Collections.Generic;
using System.Text;

namespace Library
{
    class Book
    {
        public String Title { get; set; }
        public Author Author { get; set; }

        public Book() : this("Untitled") { }
        public Book(String title) : this(title, null) { }
        public Book(String title, Author author)
        {
            Title = title;
            Author = author;
        }
        override
        public String ToString()
        {
            return Title + " by " + Author;
        }

    }
}
