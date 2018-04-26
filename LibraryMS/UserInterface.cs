using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryMS
{
    public interface IUsers
    {
        void Add(Users newUser);
        List<Users> GetAll();
        Users GetById(string username);
        List<Fine> GetFinesById(string username);
        bool IsEmployee(string username);
        Borrow checkout(int bookid, string name);
    }
}
