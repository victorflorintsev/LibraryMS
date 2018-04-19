using LibraryData;
using System;
using LibraryData.LIBDBModels;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace LibraryServices
{
    public class CustomerServices : ICustomer
    {
        private LibraryMSContext _context;
        public CustomerServices(LibraryMSContext context)
        {
            _context = context;
        }

        public void Add(Customer newCustomer)
        {
            _context.Add(newCustomer);
            _context.SaveChanges();
        }

        public IEnumerable<Customer> getAll()
        {
            return _context.Customer;
        }

        public Customer getbyID(int id)
        {
            return _context.Customer.Include(asset => asset.FirstName).Include(asset => asset.LastName).FirstOrDefault(asset => asset.CustomerId == id);
        }

        public string getFirst(int id)
        {
            return _context.Customer.FirstOrDefault(a => a.CustomerId == id).FirstName;
        }

        public string getLast(int id)
        {
            return _context.Customer.FirstOrDefault(a => a.CustomerId == id).LastName;
        }
    }
}
