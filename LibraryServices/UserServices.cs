using LibraryData;
using System;
using LibraryData.LIBDBModels;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace LibraryServices
{
    public class UserServices : IUsers
    {
        private LibraryMSContext _context;
        public UserServices(LibraryMSContext context)
        {
            _context = context;
        }

        public void Add(Users usertodb)
        {
            _context.Add(usertodb);
            _context.SaveChanges();
        }



    }
}



