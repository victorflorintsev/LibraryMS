using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryData.Models
{
   public class Patron
    {
        //Attributes of Patron/Customer Entity
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string TelephoneNumber { get; set; }

        //Foreignkey library card
        //public virtual LibraryCard LibraryCard { get; set; }

    }
}
