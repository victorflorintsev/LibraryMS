using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryMS
{
    public interface IUsers
    {
        void Add(Users newUser);
        List<Users> GetAll();
        bool isEmployee(string username);
    }
}
