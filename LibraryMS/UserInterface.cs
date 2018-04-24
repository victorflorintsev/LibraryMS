using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryMS
{
    public interface IUsers
    {
        void Add(Users newUser);
        List<Users> GetAll();
<<<<<<< HEAD
        Users GetById(string username);
        List<Fine> GetFinesById(string username);
=======
        bool isEmployee(string username);
>>>>>>> 17163e48a69fa188ec7ca8afa1ec864595346d5f
    }
}
