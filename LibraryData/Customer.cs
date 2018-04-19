using System;
using System.Collections.Generic;
using LibraryData.LIBDBModels;
using System.Text;

namespace LibraryData
{
    public interface ICustomer
    {
        //int id is the primary key
        IEnumerable<Customer> getAll();
        Customer getbyID(int id);
        void Add(Customer newMedia);
        string getFirst(int id);
        string getLast(int id);

        //1->LibraryData Interface
        //2->Controller
        //3->Models Listing
        //4->cshtml

    }
}
