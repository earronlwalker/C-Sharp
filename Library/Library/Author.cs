using System;
using System.Collections.Generic;
using System.Text;

namespace Library
{
    public class Author
    {
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public String FullName { get { return FirstName + " " + LastName; } }

        internal Book Book { get; set; }

        public Author() : this("No First Name") { }
        public Author(String lastName) : this("No First Name", lastName) { }
        public Author(String firstName, String lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        override
        public String ToString()
        {
            return FirstName + " " + LastName;
        }
    }
}
