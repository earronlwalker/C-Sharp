using System;
using System.Collections.Generic;
using System.Text;

namespace Library
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to our Library.");
            Library Library = new Library("Columbus Region Library");
            bool working = true;
            while (working)
            {
                Console.WriteLine("\nPlease, enter your choice.");
                Console.WriteLine("\n1. Create");
                Console.WriteLine("2. List");
                Console.WriteLine("3. Assign");
                Console.WriteLine("9. Quit");
                String choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        Console.WriteLine("\nWe now get to create.");
                        bool creating = true;
                        while (creating)
                        {
                            Console.WriteLine("What do you want to create?");
                            Console.WriteLine("1. Author");
                            Console.WriteLine("2. Book");
                            Console.WriteLine("9. None");
                            String createChoice = Console.ReadLine();
                            switch (createChoice)
                            {
                                case "1":
                                    Console.WriteLine("Please, enter the first name");
                                    String authorFirstName = Console.ReadLine();
                                    Console.WriteLine("Please, enter the last name");
                                    String authorLastName = Console.ReadLine();
                                    Author newAuthor = new Author(authorFirstName, authorLastName);
                                    Console.WriteLine("We created an author named " + newAuthor.FullName);
                                    Library.addAuthor(newAuthor);
                                    break;
                                case "2":
                                    Console.WriteLine("Please, enter the title for the book.");
                                    String bookTitle = Console.ReadLine();
                                    Book book = new Book(bookTitle);
                                    Console.WriteLine("We created a book titled " + book.Title);
                                    Library.addBook(book);
                                    break;
                                case "9":
                                    creating = false;
                                    break;
                                default:
                                    Console.WriteLine("I don't know that choice.");
                                    break;
                            }
                        }
                        Console.WriteLine("\nExiting creation.");
                        break;
                    case "2":
                        Console.WriteLine("\nWe now get to list.");
                        bool listing = true;
                        while (listing)
                        {
                            Console.WriteLine("What do you want to list?");
                            Console.WriteLine("\n1. Authors");
                            Console.WriteLine("2. Books");
                            Console.WriteLine("9. None");
                            String listChoice = Console.ReadLine();
                            switch (listChoice)
                            {
                                case "1":
                                    Console.WriteLine("*** Authors ***");
                                    Console.WriteLine(Library.Authors);
                                    break;
                                case "2":
                                    Console.WriteLine("*** Book List ***");
                                    Console.WriteLine(Library.Books);
                                    break;
                                case "9":
                                    listing = false;
                                    break;
                                default:
                                    Console.WriteLine("I don't know that choice.");
                                    break;
                            }

                        }
                        Console.WriteLine("\nExiting listing");
                        break;
                    case "3":
                        bool assigning = true;
                        while (assigning)
                        {
                            Console.WriteLine("What do you want to assign?");
                            Console.WriteLine("\n1. Author");
                            Console.WriteLine("9. None");
                            String assignChoice = Console.ReadLine();
                            switch (assignChoice)
                            {
                                case "1":
                                    Console.WriteLine("Please, enter the book title");
                                    String forAuthorBookTitle = Console.ReadLine();
                                    Console.WriteLine("Please, enter the author's first name");
                                    String authorFirstName = Console.ReadLine();
                                    Console.WriteLine("Please, enter the writer's last name");
                                    String authorLastName = Console.ReadLine();
                                    if (Library.assignAuthor(authorFirstName, authorLastName, forAuthorBookTitle ))
                                    {
                                        Console.WriteLine("You successfully assign the author to the book.");
                                    }
                                    else
                                    {
                                        Console.WriteLine("There was an error assigning the author to the book");
                                    }
                                    break;
                                case "9":
                                    assigning = false;
                                    break;
                                default:
                                    break;
                            }
                        }
                        Console.WriteLine("\nExiting assigning");
                        break;
                    case "9":
                        working = false;
                        break;
                    default:
                        Console.WriteLine("Not a valid choice.");
                        break;
                }
                Console.WriteLine("\n*** Thank you for using our Library Application ***\n");
            }
        }
    }
}