using System;
using System.Collections.Generic;
using System.Text;

namespace Library
{
    class Library
    {
        public String Name { get; set; }
        private Dictionary<String, Author> _authors;
        private Dictionary<String, Book> _books;

        public String Authors
        {
            get
            {
                String tempString = "";
                foreach (Author author in _authors.Values)
                {
                    tempString += author.FullName + "\n";
                }
                return tempString;
            }
        }
        public String Books
        {
            get
            {
                String tempString = "";
                foreach (Book book in _books.Values)
                {
                    tempString += book + "\n";
                }
                return tempString;
            }
        }
        public Library() : this("No Name") { }

        public Library(String name)
        {
            Name = name;
            _authors = new Dictionary<string, Author>();
            _books = new Dictionary<string, Book>();
        }
        public void addBook(Book book)
        {
            _books.Add(book.Title, book);
        }
        public void addAuthor(Author author)
        {
            _authors.Add(author.FullName, author);
        }

        public bool assignAuthor(string authorFirstName,string authorLastName, string bookTitle)
        {
            bool result = false;
            Book foundBook = null;
            Author foundAuthor = null;
            _authors.TryGetValue(authorFirstName + " " + authorLastName, out foundAuthor);
            _books.TryGetValue(bookTitle, out foundBook);
            if (foundBook != null && foundAuthor != null)
            {
                foundBook.Author = foundAuthor;
                result = true;
            }
            return result;
        }
    }
}
